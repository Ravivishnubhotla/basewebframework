using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Legendigital.Framework.Common.Utility
{
    public static class WinControlHelper
    {
        public static void BeginPutMessgae(RichTextBox richTextBox)
        {
            richTextBox.SuspendLayout();
            richTextBox.Text = "";
            richTextBox.ScrollToCaret();
            richTextBox.ResumeLayout();
        }

        public static void PerformStep(ProgressChangedEventArgs e,ProgressBar pb)
        {
            int progressStep = (e.ProgressPercentage - pb.Value);
            for (int i = 0; i < progressStep; i++)
            {
                pb.PerformStep();
            }
        }

        public static void OutPutMessgae(RichTextBox richTextBox, string text)
        {
            richTextBox.SuspendLayout();
            richTextBox.AppendText(text + "\n");
            richTextBox.ScrollToCaret();
            richTextBox.ResumeLayout();
        }

        public static void SetLastLineText(RichTextBox richTextBox, string text)
        {
            int lineIndex = richTextBox.Lines.Length - 1;

            SelectLine(richTextBox, lineIndex);
            string stext = richTextBox.SelectedText;

            while (string.IsNullOrEmpty(stext))
            {
                lineIndex--;
                SelectLine(richTextBox, lineIndex);
                stext = richTextBox.SelectedText;
            }

            richTextBox.SelectedText = text;
        }

        public static void SelectLine(RichTextBox richTextBox, int lineIndex)
        {
            int start = richTextBox.Text.Length - richTextBox.Lines[lineIndex].Length - 1;
            richTextBox.Select(start, richTextBox.Lines[lineIndex].Length);
        }

        public static void UpdateOutPutMessgae(RichTextBox richTextBox, string text)
        {
            richTextBox.SuspendLayout();
            SetLastLineText(richTextBox, text.Replace("[P]", ""));
            //MessageBox.Show(richTextBox.SelectedText);
            richTextBox.ResumeLayout();
        }

        public static void ShowProgress(RichTextBox richTextBox, string text)
        {
            if (!text.StartsWith("[P]"))
                OutPutMessgae(richTextBox, text);
            else
                UpdateOutPutMessgae(richTextBox, text.Replace("[P]", ""));
        }



    }
}
