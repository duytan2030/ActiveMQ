﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apache.NMS;
using Apache.NMS.Util;
using BusinessObject;
using Apache.NMS.ActiveMQ.Commands;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
                  

            IConnectionFactory factory = new NMSConnectionFactory("tcp://localhost:61616");
            IConnection connect = factory.CreateConnection();
            connect.Start();
            ISession session = connect.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQQueue ac = new ActiveMQQueue("Tan ne");
            IMessageProducer MessPorocedure = session.CreateProducer(ac);
            //IMessage mess = new ActiveMQTextMessage(txt_send.Text);


            //MessPorocedure.Send(mess);
            MessPorocedure.Send(session.CreateTextMessage(txt_send.Text));
            session.Close();
            connect.Stop();
        }
    }
}
