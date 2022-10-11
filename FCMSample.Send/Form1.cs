using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCMSample.Send
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            #region FCM驗證
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("private_key.json")
            });
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string token = txtToken.Text;
            string notificationTitle = txtTitle.Text;
            string notificationBody = txtContent.Text;

            // See documentation on defining a message payload.
            var message = new FirebaseAdmin.Messaging.Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "myData", "1337" },
                },
                //Token = registrationToken,
                //Topic = "all",
                Notification = new Notification()
                {
                    Title = notificationTitle,
                    Body = notificationBody
                }
            };

            if (string.IsNullOrEmpty(token))
            {
                //針對APP訂閱的主題做群發
                message.Topic = "all";
            }
            else
            {
                message.Token = token;
            }

            // Send a message to the device corresponding to the provided
            // registration token.
            string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);
        }
    }
}

