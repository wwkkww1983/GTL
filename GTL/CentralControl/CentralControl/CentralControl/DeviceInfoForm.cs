﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CentralControl
{
    public partial class DeviceInfoForm : Form
    {
        public ControlForm FatherForm;
        public BaseDevice DeviceInfo;

        public DeviceInfoForm()
        {
            InitializeComponent();
        }

        private void DeviceInfoForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            FatherForm.Enabled = false;

            if (DeviceInfo.IsVirt) 
            {
                isVirtualCheckBox.Checked = true;
            }
            deviceNameLabel.Text = DeviceInfo.Name;
            deviceIPTextBox.Text = DeviceInfo.IP;
            localIPTextBox.Text = DeviceInfo.ControlIP;
            deviceNameTextBox.Text = DeviceInfo.Name;
            identifyIDTextBox.Text = DeviceInfo.IdentifyID;
            codeTextBox.Text = DeviceInfo.Code;
            serialIDTextBox.Text = DeviceInfo.SerialID;
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            switch (DeviceInfo.CurrentDeviceType) 
            {
                case DeviceType.Dispen:
                    AutoDispenDeviceForm form = new AutoDispenDeviceForm();
                    form.FatherForm = this;
                    form.IsSocket = true;
                    if (DeviceInfo is AutoDispenVirtualDevice)
                        form.DispenDevice = (AutoDispenVirtualDevice)DeviceInfo;
                    else
                    {
                        form.DispenTwincatDevice = (AutoDispenTwincatDevice)DeviceInfo;
                        form.IsSocket = false;
                    }
                    form.Show();
                    break;
                case DeviceType.Analysis:
                    MultiTunnelDeviceForm mForm = new MultiTunnelDeviceForm();
                    mForm.FatherForm = this;
                    mForm.DeviceInfo = (MultiTunnelVirtualDevice)DeviceInfo;
                    mForm.Show();
                    break;
                case DeviceType.Clone:
                    CloneSelectionDeviceForm cForm = new CloneSelectionDeviceForm();
                    cForm.FatherForm = this;
                    cForm.IsSocket = true;
                    cForm.DeviceInfo = (CloneSelectionVirtualDevice)DeviceInfo;
                    cForm.Show();
                    break;
                case DeviceType.Liquid:
                    LiquidProcessForm lForm = new LiquidProcessForm();
                    lForm.FatherForm = this;
                    lForm.IsSocket = true;          //temp settings warning
                    lForm.alcDevice = (LiquidProcessVirtualDevice)DeviceInfo;
                    lForm.Show();
                    break;

                case DeviceType.Matrix:
                    MatrixSystemDeviceForm maForm = new MatrixSystemDeviceForm();
                    maForm.FatherForm = this;
                    maForm.IsSocket = true;
                    maForm.DeviceInfo = (MatrixSystemVirtualDevice)DeviceInfo;
                    maForm.Show();
                    break;

                case DeviceType.Storage:
                    MicroReactorForm sForm = new MicroReactorForm();
                    sForm.FatherForm = this;
                    sForm.IsSocket = true;
                    sForm.mrDevice = (MicroStorageVirtualDevice)DeviceInfo;
                    sForm.Show();
                    break;

                default:
                    break;

            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeviceInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }
    }
}
