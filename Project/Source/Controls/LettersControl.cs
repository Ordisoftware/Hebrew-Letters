/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2012-10 </created>
/// <edited> 2019-01 </edited>
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewLetters
{

  /// <summary>
  /// Provide Letters input panel Control class.
  /// </summary>
  public partial class LettersControl : UserControl
  {

    /// <summary>
    /// Indicates if a key is being processed.
    /// </summary>
    private bool KeyProcessed = false;

    /// <summary>
    /// Indicate the background color of letters panel.
    /// </summary>
    public Color LettersBackground
    {
      get { return Panel.BackColor; }
      set { Panel.BackColor = value; }
    }

    /// <summary>
    /// Indicate the background color of input textbox.
    /// </summary>
    public Color InputBackColor
    {
      get { return Input.BackColor; }
      set { Input.BackColor = value; }
    }

    /// <summary>
    /// Input textbox text changed event.
    /// </summary>
    public event EventHandler InputTextChanged
    {
      add { Input.TextChanged += value; }
      remove { Input.TextChanged -= value; }
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public LettersControl()
    {
      InitializeComponent();
      CreateLetters();
    }

    /// <summary>
    /// Create letters buttons.
    /// </summary>
    private void CreateLetters()
    {
      try
      {
        int dy = 45;
        int dx = -45;
        int x = 500 + dx;
        int y = 5;
        int n = 1;
        Label labelValue;
        Label labelKey;
        Button buttonLetter;
        Size sizeLabelValue = new Size(45, 8);
        Size sizeLabelKey = new Size(45, 13);
        Font fontLetter = new Font("Hebrew", 20.25F, FontStyle.Bold);
        Font fontValue = new Font("Microsoft Sans Serif", 6.25F);
        for ( int index = 0; index < HebrewLetters.Codes.Length; index++ )
        {
          string letter = HebrewLetters.Codes[index];
          labelKey = new Label();
          labelValue = new Label();
          buttonLetter = new Button();
          Panel.Controls.Add(labelValue);
          Panel.Controls.Add(labelKey);
          Panel.Controls.Add(buttonLetter);

          labelValue.Location = new Point(x, y + dy);
          labelValue.Size = sizeLabelKey;
          labelValue.Font = fontValue;
          labelValue.ForeColor = Color.DarkSlateGray;
          labelValue.BackColor = Color.Transparent;
          labelValue.Text = HebrewLetters.ValuesSimple[index].ToString();
          labelValue.TextAlign = ContentAlignment.MiddleCenter;

          labelKey.Location = new Point(x, y + dy + labelValue.Height + 1);
          labelKey.Size = sizeLabelKey;
          labelKey.Text = letter;
          labelKey.ForeColor = Color.DarkSlateGray;
          labelKey.BackColor = Color.Transparent;
          labelKey.TextAlign = ContentAlignment.MiddleCenter;

          buttonLetter.Location = new Point(x, y);
          buttonLetter.Size = new Size(Math.Abs(dx), dy);
          buttonLetter.FlatStyle = FlatStyle.Flat;
          buttonLetter.FlatAppearance.BorderSize = 0;
          buttonLetter.FlatAppearance.BorderColor = SystemColors.Control;
          buttonLetter.Font = fontLetter;
          buttonLetter.Text = letter;
          buttonLetter.BackColor = Color.Transparent;
          buttonLetter.TabStop = false;
          buttonLetter.Click += delegate(object sender, EventArgs e)
          {
            Input.Text = ((Button)sender).Text + Input.Text;
            OnClick(new LetterEventArgs(((Button)sender).Text));
          };
          n += 1;
          if ( n != 12 )
            x += dx;
          else
          {
            x = 500 + dx;
            y += dy + labelValue.Height + labelKey.Height + 10;
          }
        }
      }
      catch ( Exception ex )
      {
        ex.Manage(this);
      }
    }

    /// <summary>
    /// KeyPress event.
    /// </summary>
    private void Input_KeyPress(object sender, KeyPressEventArgs e)
    {
      OnKeyPress(e);
      if ( !HebrewLetters.Codes.Contains(Convert.ToString(e.KeyChar)) )
        e.KeyChar = '\x0';
      else
        KeyProcessed = true;
    }

    /// <summary>
    /// KeyUp event.
    /// </summary>
    private void Input_KeyUp(object sender, KeyEventArgs e)
    {
      if ( KeyProcessed )
      {
        KeyProcessed = false;
        if ( Input.SelectionStart != 0 ) 
          Input.SelectionStart = Input.SelectionStart - 1;
      }
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
