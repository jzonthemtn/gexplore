Namespace gExplore

    Public Class SettingsHandler

        ''' <summary>
        ''' Gets if this is the first run.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property FirstRun As Boolean
            Get
                Return Convert.ToBoolean(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("firstrun", True))
            End Get
            Set(ByVal value As Boolean)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("firstrun", value)
            End Set
        End Property

        ''' <summary>
        ''' Get or set the Google login.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property GoogleLogin As String
            Get
                Return gExplore.StringEncryption.DecryptString256Bit(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("lgn", String.Empty).ToString).ToString
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("lgn", gExplore.StringEncryption.EncryptString256Bit(value))
            End Set
        End Property

        ''' <summary>
        ''' Get or set the Google password.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property GooglePassword As String
            Get
                Return gExplore.StringEncryption.DecryptString256Bit(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("pwd", String.Empty).ToString).ToString
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("pwd", gExplore.StringEncryption.EncryptString256Bit(value))
            End Set
        End Property

        ''' <summary>
        ''' Get or set whether to minimize to the system tray.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property MinimizeToTray As Boolean
            Get
                Return Convert.ToBoolean(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("mintotray", False))
            End Get
            Set(ByVal value As Boolean)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("mintotray", value)
            End Set
        End Property

        ''' <summary>
        ''' Get or set the activation response.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ActivationResponse As String
            Get
                Return gExplore.StringEncryption.DecryptString256Bit(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("actresp", String.Empty).ToString).ToString
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("actresp", gExplore.StringEncryption.EncryptString256Bit(value))
            End Set
        End Property

        ''' <summary>
        ''' Get or set the kindle email address.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property KindleEmail As String
            Get
                Return My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("kindleemail", String.Empty).ToString
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("kindleemail", value)
            End Set
        End Property

        ''' <summary>
        ''' Get or set the license key.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property LicenseKey As String
            Get
                Return My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("licensekey", String.Empty).ToString
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("licensekey", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the last time a check for updates was done.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property LastCheckForUpdate As Date
            Get
                Return Convert.ToDateTime(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("lastupdatecheck", DateTime.MinValue))
            End Get
            Set(ByVal value As Date)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("lastupdatecheck", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets if weekly update checks are enabled.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property EnableWeeklyUpdateCheck As Boolean
            Get
                Return Convert.ToBoolean(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("enableweeklyupdatecheck", True))
            End Get
            Set(ByVal value As Boolean)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("enableweeklyupdatecheck", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets if to use a proxy server.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property UseProxy As Boolean
            Get
                Return Convert.ToBoolean(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("useproxy", False))
            End Get
            Set(ByVal value As Boolean)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("useproxy", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the address of the proxy server.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ProxyServer As String
            Get
                Return My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("proxyserver", String.Empty).ToString
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("proxyserver", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the port of the proxy server.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ProxyPort As Integer
            Get
                Return Convert.ToInt32(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("proxyport", 8080))
            End Get
            Set(ByVal value As Integer)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("proxyport", value.ToString)
            End Set

        End Property
        ''' <summary>
        ''' Gets or sets the username for the proxy server.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ProxyServerUserName As String
            Get
                Return My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("proxyserverun", String.Empty).ToString
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("proxyserverun", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the password for the proxy server.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ProxyServerPassword As String
            Get
                Return StringEncryption.DecryptString256Bit(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("proxyserverpa", String.Empty).ToString)
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("proxyserverpa", StringEncryption.EncryptString256Bit(value))
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the proxy server requires authentication.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ProxyServerAuth As Boolean
            Get
                Return Convert.ToBoolean(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("proxyserverauth", False))
            End Get
            Set(ByVal value As Boolean)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("proxyserverauth", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the user's choice to use their Gmail for sending mail. If false, mail will be sent using Gmail.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property UseCustomSMTP As Boolean
            Get
                Return Convert.ToBoolean(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("usecustomsmtp", False))
            End Get
            Set(ByVal value As Boolean)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("usecustomsmtp", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the user's SMTP server.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property SMTPHost As String
            Get
                Return My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("smtphost", String.Empty).ToString
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("smtphost", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the user's SMTP port number.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property SMTPPort As String
            Get
                Return My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("smtpport", "25").ToString
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("smtpport", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the user's SMTP server requires SSL.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property SMTPRequiresSSL As Boolean
            Get
                Return Convert.ToBoolean(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("smtpusessl", False))
            End Get
            Set(ByVal value As Boolean)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("smtpusessl", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the user's SMTP server requires authentication.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property SMTPRequiresAuth As Boolean
            Get
                Return Convert.ToBoolean(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("smtpuseauth", False))
            End Get
            Set(ByVal value As Boolean)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("smtpuseauth", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the user's SMTP user name.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property SMTPUserName As String
            Get
                Return My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("smtpuname", String.Empty).ToString
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("smtpuname", value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the user's SMTP password.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property SMTPPassword As String
            Get
                Return gExplore.StringEncryption.DecryptString256Bit(My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("smtppwd", String.Empty).ToString).ToString
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("smtppwd", gExplore.StringEncryption.EncryptString256Bit(value))
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the documents editor executable.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property DocumentsEditor As String
            Get
                Return My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").GetValue("documenteditor", String.Empty).ToString
            End Get
            Set(ByVal value As String)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\gExplore").SetValue("documenteditor", value)
            End Set
        End Property

    End Class

End Namespace