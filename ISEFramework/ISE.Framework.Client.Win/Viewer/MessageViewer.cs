using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISE.Framework.Client.Win.Viewer
{
    public enum OperationType
    {
        Insert,
        Update,
        Delete
    }
    public class MessageViewer
    {
        public static void ShowException(string exceptionMessage)
        {
            MessageBox.Show(exceptionMessage, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowMessage(string infoMessage)
        {
            MessageBox.Show(infoMessage, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowMessage(OperationType opType)
        {
            switch(opType)
            {
                case OperationType.Insert:
                    {
                        string text = "رکورد مورد نظر ذخيره شد";
                        return MessageBox.Show(text, "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    }
                    break;
                case OperationType.Delete:
                    {
                        string text = "رکورد مورد نظر حذف شد";
                        return MessageBox.Show(text, "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    }
                    break;
                case OperationType.Update:
                    {
                        string text = "تغييرات مورد نظر ذخيره شد";
                        return MessageBox.Show(text, "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    }
                    break;
            }
           return  MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowAlert(string text)
        {
            return MessageBox.Show(text, "هشدار", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
        }
        public static DialogResult ShowDeleteAlert()
        {
            string text = "آيا از حذف رکورد مورد نطر مطمئن هستيد!";
            return MessageBox.Show(text, "هشدار", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
        }
    }
}
