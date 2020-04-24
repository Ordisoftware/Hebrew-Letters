﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-04 </created>
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  public enum CaretPositionAfterPaste
  {
    Start,
    End
  }

  public enum TextInsertingMode
  {
    Full,
    Selected
  }

  public delegate void InsertingTextEventHandler(object sender, TextInsertingMode mode, ref string text);

  public partial class UndoRedoTextBox : TextBox
  {

    private bool SetTextMutex;
    private UndoRedoItem Previous = new UndoRedoItem();
    private Stack<UndoRedoItem> UndoStack = new Stack<UndoRedoItem>();
    private Stack<UndoRedoItem> RedoStack = new Stack<UndoRedoItem>();

    public CaretPositionAfterPaste CaretAfterPaste { get; set; }
      = CaretPositionAfterPaste.End;

    public event InsertingTextEventHandler InsertingText;

    public override string Text
    {
      get { return base.Text; }
      set
      {
        if ( value == null ) value = "";
        if ( value == Text ) return;
        if ( InsertingText != null ) InsertingText(this, TextInsertingMode.Full, ref value);
        if ( value.Length > MaxLength ) return;
        try
        {
          bool first = string.IsNullOrEmpty(Text) && UndoStack.Count == 0;
          if ( !SetTextMutex )
          {
            SetTextMutex = true;
            if ( !first ) AddUndo();
          }
          base.Text = value;
          if ( !first ) SetCaret(0, value.Length);
          SelectionLength = 0;
        }
        finally
        {
          SetTextMutex = false;
        }
      }
    }

    public override string SelectedText
    {
      get { return base.SelectedText; }
      set
      {
        if ( value == null ) value = "";
        if ( value == base.SelectedText ) return;
        if ( InsertingText != null ) InsertingText(this, TextInsertingMode.Selected, ref value);
        if ( Text.Length + value.Length - SelectionLength > MaxLength ) return;
        try
        {
          if ( !SetTextMutex )
          {
            SetTextMutex = true;
            AddUndo();
          }
          int selectionStart = SelectionStart;
          base.SelectedText = value;
          SetCaret(selectionStart, value.Length);
        }
        finally
        {
          SetTextMutex = false;
        }
      }
    }

    public UndoRedoTextBox()
    {
      InitializeComponent();
      ActionUndo.Click += ActionUndo_Click;
      ActionRedo.Click += ActionRedo_Click;
      ActionCopy.Click += ActionCopy_Click;
      ActionCut.Click += ActionCut_Click;
      ActionPaste.Click += ActionPaste_Click;
      ActionSelectAll.Click += ActionSelectAll_Click;
    }

    private void UpdateMenuItems()
    {
      ActionUndo.Enabled = UndoStack.Count != 0;
      ActionRedo.Enabled = RedoStack.Count != 0;
      ActionCopy.Enabled = !string.IsNullOrEmpty(SelectedText);
      ActionCut.Enabled = ActionCopy.Enabled;
      ActionPaste.Enabled = !string.IsNullOrEmpty(Clipboard.GetText());
      ActionSelectAll.Enabled = !string.IsNullOrEmpty(base.Text) && SelectionLength != TextLength;
    }

    private void ContextMenuEdit_Opened(object sender, EventArgs e)
    {
      UpdateMenuItems();
    }

    private void AddUndo()
    {
      if ( base.Text == null ) return;
      Previous.Set(base.Text, SelectionStart);
      UndoStack.Push(Previous);
      if ( RedoStack.Count > 0 )
        RedoStack.Clear();
    }

    private void SetCaret(int pos, int length)
    {
      switch ( CaretAfterPaste )
      {
        case CaretPositionAfterPaste.Start:
          SelectionStart = pos;
          break;
        case CaretPositionAfterPaste.End:
          SelectionStart = pos + length;
          break;
        default:
          throw new NotImplementedException();
      }
    }

    private void TextChangedEvent(object sender, EventArgs e)
    {
      if ( SetTextMutex ) return;
      UndoStack.Push(Previous);
      RedoStack.Clear();
    }

    private void KeyPressEvent(object sender, KeyPressEventArgs e)
    {
      if ( e.KeyChar == '\u0018' ) // Ctrl+X
        ActionCut.PerformClick();
      else
      if ( e.KeyChar == '\u0003' ) // Ctrl+C
        ActionCopy.PerformClick();
      else
      if ( e.KeyChar == '\u0016' ) // Ctrl+V
        ActionPaste.PerformClick();
      else
      if ( e.KeyChar == '\b' && SelectionStart > 0 ) // Back Space
      {
        var pos = SelectionStart;
        Text = Text.Remove(SelectionStart - 1, 1);
        SelectionStart = pos - 1;
      }
      else
        return;
      e.Handled = true;
    }

    private void KeyDownEvent(object sender, KeyEventArgs e)
    {
      Func<bool, Keys, Action, bool> check = (condition, key, action) =>
      {
        if ( !condition || e.KeyCode != key ) return false;
        e.SuppressKeyPress = true;
        if ( action != null ) action();
        return true;
      };
      UpdateMenuItems();
      if ( !check(e.Control, Keys.A, ActionSelectAll.PerformClick) )
        if ( !check(e.Control, Keys.Z, ActionUndo.PerformClick) )
          if ( !check(e.Control, Keys.Y, ActionRedo.PerformClick) )
            if ( !check(e.Control, Keys.Insert, ActionCopy.PerformClick) )
              if ( !check(e.Shift, Keys.Delete, ActionCut.PerformClick) )
                if ( !check(e.Shift, Keys.Insert, ActionPaste.PerformClick) )
                  Previous.Set(Text, SelectionStart);
    }

    private void ActionSelectAll_Click(object sender, EventArgs e)
    {
      if ( sender is ToolStripMenuItem && !Focused ) Focus();
      SelectAll();
    }

    private void ActionCopy_Click(object sender, EventArgs e)
    {
      if ( sender is ToolStripMenuItem && !Focused ) Focus();
      if ( string.IsNullOrEmpty(SelectedText) ) return;
      Clipboard.SetText(SelectedText);
    }

    private void ActionCut_Click(object sender, EventArgs e)
    {
      if ( sender is ToolStripMenuItem && !Focused ) Focus();
      if ( string.IsNullOrEmpty(SelectedText) ) return;
      if ( !Enabled || ReadOnly ) return;
      Clipboard.SetText(SelectedText);
      int selectionStart = SelectionStart;
      Text = Text.Remove(selectionStart, SelectionLength);
      SelectionStart = selectionStart;
    }

    private void ActionPaste_Click(object sender, EventArgs e)
    {
      if ( sender is ToolStripMenuItem && !Focused ) Focus();
      if ( string.IsNullOrEmpty(Clipboard.GetText()) ) return;
      if ( !Enabled || ReadOnly ) return;
      SelectedText = Clipboard.GetText();
    }

    private void ActionUndo_Click(object sender, EventArgs e)
    {
      if ( sender is ToolStripMenuItem && !Focused ) Focus();
      if ( !Enabled || ReadOnly ) return;
      if ( UndoStack.Count == 0 ) return;
      try
      {
        SetTextMutex = true;
        Previous.Set(Text, SelectionStart);
        RedoStack.Push(new UndoRedoItem().Set(Text, SelectionStart));
        var item = UndoStack.Pop();
        Text = item.Text;
        SelectionStart = item.SelectionStart;
      }
      finally
      {
        SetTextMutex = false;
      }
    }

    private void ActionRedo_Click(object sender, EventArgs e)
    {
      if ( sender is ToolStripMenuItem && !Focused ) Focus();
      if ( !Enabled || ReadOnly ) return;
      if ( RedoStack.Count == 0 ) return;
      try
      {
        SetTextMutex = true;
        UndoStack.Push(new UndoRedoItem().Set(Text, SelectionStart));
        var item = RedoStack.Pop();
        Text = item.Text;
        SelectionStart = item.SelectionStart;
        Previous.Set(Text, SelectionStart);
      }
      finally
      {
        SetTextMutex = false;
      }
    }

  }

  public struct UndoRedoItem
  {
    public string Text;
    public int SelectionStart;
    public UndoRedoItem Set(string text, int selectionStart)
    {
      Text = text;
      SelectionStart = selectionStart;
      return this;
    }
  }

}
