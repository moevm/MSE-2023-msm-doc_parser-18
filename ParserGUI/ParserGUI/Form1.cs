﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParserGUI
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();
        string Result;

        private void TextBoxChoose_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckBoxSave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxSave_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonChooseFile_Click(object sender, EventArgs e)
        {
            if (ofd.FileName != "")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XML|*.xml";
                sfd.Title = "Сохранить результат";
                sfd.ShowDialog();

                if (sfd.FileName != "")
                {
                    TextBoxSave.Text = sfd.FileName;
                    Stream NewFile = sfd.OpenFile();
                    StreamWriter sw = new StreamWriter(NewFile);
                    sw.WriteLine(Result);
                    sw.Close();
                    NewFile.Close();
                    MessageBox.Show("Файл успешно сохранен!");
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл!");
            }
        }

            private void ButtonFile_Click(object sender, EventArgs e)
        {
            ofd.Filter = "PDF|*.pdf";
            ofd.Title = "Выбор документа";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                if (ofd.FileName != null)
                {
                    TextBoxChoose.Text = ofd.FileName;
                }
            }
        }
        private void ButtonStart_Click(object sender, EventArgs e)
        {
           if (ofd.FileName != "")
                {
                    Result = Parser.PDFToString(ofd.FileName);
                    RTBOutput.Text = Result;
                }
                else
                {
                    MessageBox.Show("Вы не выбрали файл!");
                }
            }
        }
    }

