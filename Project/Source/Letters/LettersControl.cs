/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;
using Ordisoftware.Core.Diagnostics;

namespace Ordisoftware.HebrewLettriq
{

  /// <summary>
  /// Provide LettersControl class.
  /// </summary>
  public partial class LettersControl : UserControl
  {

    /// <summary>
    /// Indicates if a key is being processed.
    /// </summary>
    [ThreadStatic]
    private bool NewKeyPressed = false;

    /// <summary>
    /// Create letters buttons.
    /// </summary>
    private void CreateLetters()
    {
      //if ( SystemManager.Process.IsDesigntime ) return;
      try
      {
        int dy = 45;
        int dx = -dy;
        int x = 500 + dx;
        int y = 5;
        int n = 1;
        Label label;
        Button button;
        Size size = new Size(45, 13);
        Font font = new Font("Hebrew", 20.25F, FontStyle.Bold);
        foreach ( Letter l in Letters.Instance.Values )
        {
          label = new Label();
          button = new Button();
          Panel.Controls.Add(label);
          Panel.Controls.Add(button);
          label.Location = new Point(x, y + dy);
          label.Size = size;
          label.Text = l.Code.ToString();
          label.TextAlign = ContentAlignment.MiddleCenter;
          button.Location = new Point(x, y);
          button.Size = new Size(Math.Abs(dx), dy);
          button.FlatStyle = FlatStyle.Flat;
          button.FlatAppearance.BorderColor = SystemColors.Control;
          button.Font = font;
          button.Text = new string(l.Code, 1);
          button.TabStop = false;
          button.Click += delegate(object sender, EventArgs e)
          {
            Input.Text = ((Button)sender).Text + Input.Text;
            this.OnClick(new LetterEventArgs(((Button)sender).Text));
          };
          n += 1;
          if ( n != 12 ) x += dx;
          else
          {
            x = 500 + dx;
            y += dy + 13 + 10;
          }
        }
      }
      catch ( Exception except )
      {
        Debugger.ManageException(this, except);
      }
    }

    /// <summary>
    /// KeyPress event.
    /// </summary>
    private void Input_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.OnKeyPress(e);
      if ( !Letters.Instance.Keys.Contains(e.KeyChar) ) e.KeyChar = '\x0';
      else NewKeyPressed = true;
    }

    /// <summary>
    /// KeyUp event.
    /// </summary>
    private void Input_KeyUp(object sender, KeyEventArgs e)
    {
      if ( NewKeyPressed )
      {
        NewKeyPressed = false;
        if ( Input.SelectionStart != 0 ) 
          Input.SelectionStart = Input.SelectionStart - 1;
      }
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public LettersControl()
    {
      InitializeComponent();
      CreateLetters();
    }

  }

  /// <summary>
  /// Provide LetterEventArgs class.
  /// </summary>
  public class LetterEventArgs : EventArgs
  {
    public string LetterCode { get; private set; }
    public LetterEventArgs(string lettercode) { LetterCode = lettercode; }
  }

}
