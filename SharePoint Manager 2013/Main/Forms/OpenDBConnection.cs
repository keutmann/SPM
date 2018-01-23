using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
//using Microsoft.SqlServer.Management.Common;
using Microsoft.Win32;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Forms
{
    public partial class OpenDBConnection : Form
    {
        private const string RegConnectionsGroup = @"Config\Connections\";

        //private bool hasTablesBeenloaded = false;

        private string _ConnectionString = string.Empty;
        public string ConnectionString
        {
            get
            {
                return ConnectionBuilder.ConnectionString;
            }
            set
            {
                ConnectionBuilder = new SqlConnectionStringBuilder(value);
            }
        }

        //private ServerConnection _Connection = null;
        //public ServerConnection Connection
        //{
        //    get
        //    {
        //        if (_Connection == null)
        //        {

        //                _Connection = new ServerConnection();
        //                _Connection.ConnectAsUser = false;
                    
        //        }
        //        return _Connection;
        //    }
        //    set
        //    {
        //        _Connection = value;
        //    }
        //}

        private SqlConnectionStringBuilder _ConnectionBuilder = null;
        public SqlConnectionStringBuilder ConnectionBuilder
        {
            get
            {
                if (_ConnectionBuilder == null)
                {
                    _ConnectionBuilder = new SqlConnectionStringBuilder();
                }
                return _ConnectionBuilder;
            }
            set
            {
                _ConnectionBuilder = value;
            }
        }

        public OpenDBConnection()
        {
            InitializeComponent();
            //string connString = SPMRegistry.GetValue(RegConnectionsGroup, cbServers.SelectedItem as string) as string;

        }

        //private void LoadConnectionStrings()
        //{
        //    RegistryKey key = SPMRegistry.GetKey(RegConnectionsGroup);
        //    foreach(string name in key.GetSubKeyNames())
        //    {
        //        cbServers.Items.Add(name);
        //    }
        //}

        private void ConfigControls()
        {
            if (ConnectionBuilder.DataSource.Length > 0)
            {
                //int index = cbServers.Items.IndexOf(ConnectionBuilder.DataSource);
                //if (index < 0)
                //{
                //    cbServers.Items.Add(ConnectionBuilder.DataSource);
                //    cbServers.SelectedIndex = 0;
                //}
                //else
                //{
                //    cbServers.SelectedIndex = index;
                //}
                tbServer.Text = ConnectionBuilder.DataSource;
                
             }
            if (ConnectionBuilder.InitialCatalog.Length > 0)
            {
                //int index = cbSelectDatabase.Items.IndexOf(ConnectionBuilder.InitialCatalog);
                //if (index < 0)
                //{
                //    cbSelectDatabase.Items.Add(ConnectionBuilder.InitialCatalog);
                //    cbSelectDatabase.SelectedIndex = 0;
                //}
                //else
                //{
                //    cbSelectDatabase.SelectedIndex = index;
                //}
                tbDatabase.Text = ConnectionBuilder.InitialCatalog;
            }

            if (ConnectionBuilder.IntegratedSecurity)
            {
                rbWindowsAuthentication.Checked = true;
            }
            else
            {
                rbSQLserverAuthentication.Checked = true;
                tbUserName.Text = ConnectionBuilder.UserID;
                tbPassword.Text = ConnectionBuilder.Password;
            }
            
        }

        public void SetConnectionString()
        {
            ConnectionBuilder.DataSource = tbServer.Text;
            ConnectionBuilder.InitialCatalog = tbDatabase.Text;

            ConnectionBuilder.IntegratedSecurity = !rbSQLserverAuthentication.Checked;
 
            if (!ConnectionBuilder.IntegratedSecurity)
            {
                ConnectionBuilder.UserID = tbUserName.Text;
                ConnectionBuilder.Password = tbPassword.Text;
            }

        }

        private void AddDBConnection_Load(object sender, EventArgs e)
        {
//            LoadConnectionStrings();
            InitializeInterfaceStrings();
            ConfigControls();
        }

        //private void btnRefresh_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;

        //        //  Get a list of SQL servers available on the networks
        //        DataTable dtSQLServers = SmoApplication.EnumAvailableSqlServers(false);

        //        string localServerName = "";
        //        if (cbServers.Items.Count == 0)
        //        {
        //            //  By default select the local server
        //            Server localServer = new Server();
        //            localServerName = localServer.Name;
        //        }
        //        else
        //        {
        //            localServerName = cbServers.SelectedText;
        //        }

        //        string fullName = string.Empty;

        //        foreach (DataRow drServer in dtSQLServers.Rows)
        //        {
        //            String serverName = drServer["Server"].ToString();

        //            if (drServer["Instance"] != null && drServer["Instance"].ToString().Length > 0)
        //            {
        //                fullName = serverName + @"\" + drServer["Instance"].ToString();
        //            }

        //            if (cbServers.Items.IndexOf(fullName) < 0)
        //            {
        //                int index = cbServers.Items.Add(fullName);
        //                if(String.Compare(serverName, localServerName, true) == 0)
        //                {
        //                    cbServers.SelectedIndex = index;
        //                }
        //                Connection.ServerInstance = fullName;
        //            }
        //        }
        //    }
        //    catch (SmoException smoException)
        //    {
        //        MessageBox.Show(smoException.ToString());
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.ToString());
        //    }
        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }

        //}

        //private void cbSelectDatabase_DropDown(object sender, EventArgs e)
        //{
        //    if (!hasTablesBeenloaded && cbServers.Items.Count > 0)
        //    {
        //        try
        //        {
        //            this.Cursor = Cursors.WaitCursor;

        //            //  Fill the databases combo
        //            cbSelectDatabase.Items.Clear();
  

        //            Server SelectedServer = new Server(cbServers.Text);
        //            Int32 DBCount = 0;
        //            foreach (Database db in SelectedServer.Databases)
        //            {
        //                if (!db.IsSystemObject)
        //                {
        //                    DBCount++;
        //                    cbSelectDatabase.Items.Add(db.Name);
        //                }
        //            }

        //            if (DBCount == 0)
        //            {
        //                MessageBox.Show("Did not find any SQL Server 2005 servers.");
        //            }

        //            hasTablesBeenloaded = true;

        //        }
        //        catch (SmoException smoException)
        //        {
        //            MessageBox.Show(smoException.ToString());
        //        }
        //        catch (Exception exception)
        //        {
        //            MessageBox.Show(exception.ToString());
        //        }
        //        finally
        //        {
        //            this.Cursor = Cursors.Default;
        //        }
        //    }
        //}

        //private void cbServers_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    hasTablesBeenloaded = false;

        //    string servername = cbServers.SelectedItem as string;
        //    string conn = SPMRegistry.GetValue(RegConnectionsGroup, servername) as string;
        //    if (conn != null && conn.Length > 0)
        //    {
        //        ConnectionString = conn;
        //        ConfigControls();
        //    }
              
        //}

        private void rbWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            panelSQLServerAuthentication.Enabled = rbSQLserverAuthentication.Checked;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SetConnectionString();

            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            
            try
            {
                sqlConn.Open();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                sqlConn.Close();
            }
            MessageBox.Show(SPMLocalization.GetString("Succes"), SPMLocalization.GetString("Testing_Database_Connection"));
        }

        //private void cbSelectDatabase_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ConnectionBuilder.InitialCatalog = cbSelectDatabase.SelectedItem as string;

        //}

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetConnectionString();

            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionString);
            //if (!ConnectionBuilder.IntegratedSecurity && !cbSaveMyPassword.Checked)
            //{
            //    builder.Password = "";
            //}
 
            //SPMRegistry.SetValue(RegConnectionsGroup, cbServers.SelectedText, builder.ToString());
        }

        private void InitializeInterfaceStrings()
        {
            label1.Text                     = SPMLocalization.GetString("Interface_EnterInfo_Text");
            lblServerName.Text              = SPMLocalization.GetString("Interface_ServerName");
            groupBox1.Text                  = SPMLocalization.GetString("Interface_LogOn");
            lblPassword.Text                = SPMLocalization.GetString("Interface_Password");
            label2.Text                     = SPMLocalization.GetString("Interface_UserName");
            rbSQLserverAuthentication.Text  = SPMLocalization.GetString("Interface_UseSQLServerAuth");
            rbWindowsAuthentication.Text    = SPMLocalization.GetString("Interface_UseWindowsAuth");
            groupBox2.Text                  = SPMLocalization.GetString("Interface_ConnectToSP");
            lblSelectDatabase.Text          = SPMLocalization.GetString("Interface_EnterConfigDB");
            btnCancel.Text                  = SPMLocalization.GetString("Interface_ButtonCancel");
            btnOK.Text                      = SPMLocalization.GetString("Interface_ButtonOK");
            btnTestConnection.Text          = SPMLocalization.GetString("Interface_TestConn");
            this.Text                       = SPMLocalization.GetString("Interface_OpenConn");
        }
    }
}