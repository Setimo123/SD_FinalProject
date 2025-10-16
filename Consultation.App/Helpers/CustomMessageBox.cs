using System;
using System.Drawing;
using System.Windows.Forms;

namespace Consultation.App.Helpers
{
    /// <summary>
    /// Custom MessageBox helper with font size 14
    /// </summary>
    public static class CustomMessageBox
    {
        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            // Create a custom form for larger font display
            Form messageForm = new Form
            {
                Width = 500,
                Height = 250,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowIcon = false,
                Font = new Font("Segoe UI", 14F, FontStyle.Regular)
            };

            // Create icon picture box
            PictureBox iconBox = new PictureBox
            {
                Location = new Point(20, 20),
                Size = new Size(48, 48),
                SizeMode = PictureBoxSizeMode.CenterImage
            };

            // Set icon based on MessageBoxIcon
            switch (icon)
            {
                case MessageBoxIcon.Question:
                    iconBox.Image = SystemIcons.Question.ToBitmap();
                    break;
                case MessageBoxIcon.Warning:
                    iconBox.Image = SystemIcons.Warning.ToBitmap();
                    break;
                case MessageBoxIcon.Error:
                    iconBox.Image = SystemIcons.Error.ToBitmap();
                    break;
                case MessageBoxIcon.Information:
                    iconBox.Image = SystemIcons.Information.ToBitmap();
                    break;
            }

            // Create message label
            Label messageLabel = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 14F, FontStyle.Regular),
                AutoSize = false,
                Location = new Point(80, 20),
                Size = new Size(400, 120),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Create buttons based on MessageBoxButtons
            Button button1 = null, button2 = null;
            int buttonWidth = 100;
            int buttonHeight = 40;
            int buttonY = messageForm.Height - 80;

            if (buttons == MessageBoxButtons.YesNo)
            {
                button1 = new Button
                {
                    Text = "Yes",
                    Font = new Font("Segoe UI", 14F, FontStyle.Regular),
                    DialogResult = DialogResult.Yes,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(messageForm.Width / 2 - buttonWidth - 10, buttonY)
                };

                button2 = new Button
                {
                    Text = "No",
                    Font = new Font("Segoe UI", 14F, FontStyle.Regular),
                    DialogResult = DialogResult.No,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(messageForm.Width / 2 + 10, buttonY)
                };

                messageForm.Controls.Add(button1);
                messageForm.Controls.Add(button2);

                // Set default button
                if (defaultButton == MessageBoxDefaultButton.Button2)
                {
                    messageForm.AcceptButton = button2;
                    button2.Select();
                }
                else
                {
                    messageForm.AcceptButton = button1;
                    button1.Select();
                }

                messageForm.CancelButton = button2;
            }
            else if (buttons == MessageBoxButtons.OK)
            {
                button1 = new Button
                {
                    Text = "OK",
                    Font = new Font("Segoe UI", 14F, FontStyle.Regular),
                    DialogResult = DialogResult.OK,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point((messageForm.Width - buttonWidth) / 2, buttonY)
                };

                messageForm.Controls.Add(button1);
                messageForm.AcceptButton = button1;
            }

            messageForm.Controls.Add(iconBox);
            messageForm.Controls.Add(messageLabel);

            return messageForm.ShowDialog();
        }
    }
}
