﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MTD.DAL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MTD")]
	public partial class MTDDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblRole(tblRole instance);
    partial void UpdatetblRole(tblRole instance);
    partial void DeletetblRole(tblRole instance);
    partial void InserttblAccount(tblAccount instance);
    partial void UpdatetblAccount(tblAccount instance);
    partial void DeletetblAccount(tblAccount instance);
    partial void InserttblDictType(tblDictType instance);
    partial void UpdatetblDictType(tblDictType instance);
    partial void DeletetblDictType(tblDictType instance);
    partial void InserttblWord(tblWord instance);
    partial void UpdatetblWord(tblWord instance);
    partial void DeletetblWord(tblWord instance);
    partial void InserttblWordHistory(tblWordHistory instance);
    partial void UpdatetblWordHistory(tblWordHistory instance);
    partial void DeletetblWordHistory(tblWordHistory instance);
    partial void InserttblPlace(tblPlace instance);
    partial void UpdatetblPlace(tblPlace instance);
    partial void DeletetblPlace(tblPlace instance);
    partial void InserttblUser(tblUser instance);
    partial void UpdatetblUser(tblUser instance);
    partial void DeletetblUser(tblUser instance);
    #endregion
		
		public MTDDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MTDDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MTDDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MTDDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MTDDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblRole> tblRoles
		{
			get
			{
				return this.GetTable<tblRole>();
			}
		}
		
		public System.Data.Linq.Table<tblAccount> tblAccounts
		{
			get
			{
				return this.GetTable<tblAccount>();
			}
		}
		
		public System.Data.Linq.Table<tblDictType> tblDictTypes
		{
			get
			{
				return this.GetTable<tblDictType>();
			}
		}
		
		public System.Data.Linq.Table<tblWord> tblWords
		{
			get
			{
				return this.GetTable<tblWord>();
			}
		}
		
		public System.Data.Linq.Table<tblWordHistory> tblWordHistories
		{
			get
			{
				return this.GetTable<tblWordHistory>();
			}
		}
		
		public System.Data.Linq.Table<tblPlace> tblPlaces
		{
			get
			{
				return this.GetTable<tblPlace>();
			}
		}
		
		public System.Data.Linq.Table<tblUser> tblUsers
		{
			get
			{
				return this.GetTable<tblUser>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblRole")]
	public partial class tblRole : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Code;
		
		private string _Text;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCodeChanging(string value);
    partial void OnCodeChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    #endregion
		
		public tblRole()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Text", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this.OnTextChanging(value);
					this.SendPropertyChanging();
					this._Text = value;
					this.SendPropertyChanged("Text");
					this.OnTextChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblAccount")]
	public partial class tblAccount : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _UserName;
		
		private string _Email;
		
		private string _Password;
		
		private System.DateTime _Register_Date;
		
		private string _Active_Code;
		
		private System.DateTime _Active_Date;
		
		private short _State;
		
		private bool _Del_Flag;
		
		private int _RoleId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnRegister_DateChanging(System.DateTime value);
    partial void OnRegister_DateChanged();
    partial void OnActive_CodeChanging(string value);
    partial void OnActive_CodeChanged();
    partial void OnActive_DateChanging(System.DateTime value);
    partial void OnActive_DateChanged();
    partial void OnStateChanging(short value);
    partial void OnStateChanged();
    partial void OnDel_FlagChanging(bool value);
    partial void OnDel_FlagChanged();
    partial void OnRoleIdChanging(int value);
    partial void OnRoleIdChanged();
    #endregion
		
		public tblAccount()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Register_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Register_Date
		{
			get
			{
				return this._Register_Date;
			}
			set
			{
				if ((this._Register_Date != value))
				{
					this.OnRegister_DateChanging(value);
					this.SendPropertyChanging();
					this._Register_Date = value;
					this.SendPropertyChanged("Register_Date");
					this.OnRegister_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active_Code", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string Active_Code
		{
			get
			{
				return this._Active_Code;
			}
			set
			{
				if ((this._Active_Code != value))
				{
					this.OnActive_CodeChanging(value);
					this.SendPropertyChanging();
					this._Active_Code = value;
					this.SendPropertyChanged("Active_Code");
					this.OnActive_CodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Active_Date
		{
			get
			{
				return this._Active_Date;
			}
			set
			{
				if ((this._Active_Date != value))
				{
					this.OnActive_DateChanging(value);
					this.SendPropertyChanging();
					this._Active_Date = value;
					this.SendPropertyChanged("Active_Date");
					this.OnActive_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_State", DbType="SmallInt NOT NULL")]
		public short State
		{
			get
			{
				return this._State;
			}
			set
			{
				if ((this._State != value))
				{
					this.OnStateChanging(value);
					this.SendPropertyChanging();
					this._State = value;
					this.SendPropertyChanged("State");
					this.OnStateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Del_Flag", DbType="Bit NOT NULL")]
		public bool Del_Flag
		{
			get
			{
				return this._Del_Flag;
			}
			set
			{
				if ((this._Del_Flag != value))
				{
					this.OnDel_FlagChanging(value);
					this.SendPropertyChanging();
					this._Del_Flag = value;
					this.SendPropertyChanged("Del_Flag");
					this.OnDel_FlagChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleId", DbType="Int NOT NULL")]
		public int RoleId
		{
			get
			{
				return this._RoleId;
			}
			set
			{
				if ((this._RoleId != value))
				{
					this.OnRoleIdChanging(value);
					this.SendPropertyChanging();
					this._RoleId = value;
					this.SendPropertyChanged("RoleId");
					this.OnRoleIdChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblDictType")]
	public partial class tblDictType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Text;
		
		private bool _IsDisplay;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    partial void OnIsDisplayChanging(bool value);
    partial void OnIsDisplayChanged();
    #endregion
		
		public tblDictType()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Text", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this.OnTextChanging(value);
					this.SendPropertyChanging();
					this._Text = value;
					this.SendPropertyChanged("Text");
					this.OnTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDisplay", DbType="Bit NOT NULL")]
		public bool IsDisplay
		{
			get
			{
				return this._IsDisplay;
			}
			set
			{
				if ((this._IsDisplay != value))
				{
					this.OnIsDisplayChanging(value);
					this.SendPropertyChanging();
					this._IsDisplay = value;
					this.SendPropertyChanged("IsDisplay");
					this.OnIsDisplayChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblWords")]
	public partial class tblWord : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Key;
		
		private string _ShortCut;
		
		private string _Value;
		
		private string _ImageUrl;
		
		private int _Dict_Type;
		
		private int _State;
		
		private int _Update_By;
		
		private System.DateTime _Update_Date;
		
		private System.Nullable<bool> _Del_Flag;
		
		private System.Nullable<int> _Del_By;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnKeyChanging(string value);
    partial void OnKeyChanged();
    partial void OnShortCutChanging(string value);
    partial void OnShortCutChanged();
    partial void OnValueChanging(string value);
    partial void OnValueChanged();
    partial void OnImageUrlChanging(string value);
    partial void OnImageUrlChanged();
    partial void OnDict_TypeChanging(int value);
    partial void OnDict_TypeChanged();
    partial void OnStateChanging(int value);
    partial void OnStateChanged();
    partial void OnUpdate_ByChanging(int value);
    partial void OnUpdate_ByChanged();
    partial void OnUpdate_DateChanging(System.DateTime value);
    partial void OnUpdate_DateChanged();
    partial void OnDel_FlagChanging(System.Nullable<bool> value);
    partial void OnDel_FlagChanged();
    partial void OnDel_ByChanging(System.Nullable<int> value);
    partial void OnDel_ByChanged();
    #endregion
		
		public tblWord()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Key]", Storage="_Key", DbType="NVarChar(2000) NOT NULL", CanBeNull=false)]
		public string Key
		{
			get
			{
				return this._Key;
			}
			set
			{
				if ((this._Key != value))
				{
					this.OnKeyChanging(value);
					this.SendPropertyChanging();
					this._Key = value;
					this.SendPropertyChanged("Key");
					this.OnKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShortCut", DbType="NVarChar(100)")]
		public string ShortCut
		{
			get
			{
				return this._ShortCut;
			}
			set
			{
				if ((this._ShortCut != value))
				{
					this.OnShortCutChanging(value);
					this.SendPropertyChanging();
					this._ShortCut = value;
					this.SendPropertyChanged("ShortCut");
					this.OnShortCutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if ((this._Value != value))
				{
					this.OnValueChanging(value);
					this.SendPropertyChanging();
					this._Value = value;
					this.SendPropertyChanged("Value");
					this.OnValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImageUrl", DbType="NVarChar(MAX)")]
		public string ImageUrl
		{
			get
			{
				return this._ImageUrl;
			}
			set
			{
				if ((this._ImageUrl != value))
				{
					this.OnImageUrlChanging(value);
					this.SendPropertyChanging();
					this._ImageUrl = value;
					this.SendPropertyChanged("ImageUrl");
					this.OnImageUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Dict_Type", DbType="Int NOT NULL")]
		public int Dict_Type
		{
			get
			{
				return this._Dict_Type;
			}
			set
			{
				if ((this._Dict_Type != value))
				{
					this.OnDict_TypeChanging(value);
					this.SendPropertyChanging();
					this._Dict_Type = value;
					this.SendPropertyChanged("Dict_Type");
					this.OnDict_TypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_State", DbType="Int NOT NULL")]
		public int State
		{
			get
			{
				return this._State;
			}
			set
			{
				if ((this._State != value))
				{
					this.OnStateChanging(value);
					this.SendPropertyChanging();
					this._State = value;
					this.SendPropertyChanged("State");
					this.OnStateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Update_By", DbType="Int NOT NULL")]
		public int Update_By
		{
			get
			{
				return this._Update_By;
			}
			set
			{
				if ((this._Update_By != value))
				{
					this.OnUpdate_ByChanging(value);
					this.SendPropertyChanging();
					this._Update_By = value;
					this.SendPropertyChanged("Update_By");
					this.OnUpdate_ByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Update_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Update_Date
		{
			get
			{
				return this._Update_Date;
			}
			set
			{
				if ((this._Update_Date != value))
				{
					this.OnUpdate_DateChanging(value);
					this.SendPropertyChanging();
					this._Update_Date = value;
					this.SendPropertyChanged("Update_Date");
					this.OnUpdate_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Del_Flag", DbType="Bit")]
		public System.Nullable<bool> Del_Flag
		{
			get
			{
				return this._Del_Flag;
			}
			set
			{
				if ((this._Del_Flag != value))
				{
					this.OnDel_FlagChanging(value);
					this.SendPropertyChanging();
					this._Del_Flag = value;
					this.SendPropertyChanged("Del_Flag");
					this.OnDel_FlagChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Del_By", DbType="Int")]
		public System.Nullable<int> Del_By
		{
			get
			{
				return this._Del_By;
			}
			set
			{
				if ((this._Del_By != value))
				{
					this.OnDel_ByChanging(value);
					this.SendPropertyChanging();
					this._Del_By = value;
					this.SendPropertyChanged("Del_By");
					this.OnDel_ByChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblWordHistory")]
	public partial class tblWordHistory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Word_Id;
		
		private int _User_Id;
		
		private bool _Del_Flag;
		
		private System.DateTime _Update_Date;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnWord_IdChanging(int value);
    partial void OnWord_IdChanged();
    partial void OnUser_IdChanging(int value);
    partial void OnUser_IdChanged();
    partial void OnDel_FlagChanging(bool value);
    partial void OnDel_FlagChanged();
    partial void OnUpdate_DateChanging(System.DateTime value);
    partial void OnUpdate_DateChanged();
    #endregion
		
		public tblWordHistory()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Word_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Word_Id
		{
			get
			{
				return this._Word_Id;
			}
			set
			{
				if ((this._Word_Id != value))
				{
					this.OnWord_IdChanging(value);
					this.SendPropertyChanging();
					this._Word_Id = value;
					this.SendPropertyChanged("Word_Id");
					this.OnWord_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_User_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int User_Id
		{
			get
			{
				return this._User_Id;
			}
			set
			{
				if ((this._User_Id != value))
				{
					this.OnUser_IdChanging(value);
					this.SendPropertyChanging();
					this._User_Id = value;
					this.SendPropertyChanged("User_Id");
					this.OnUser_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Del_Flag", DbType="Bit NOT NULL")]
		public bool Del_Flag
		{
			get
			{
				return this._Del_Flag;
			}
			set
			{
				if ((this._Del_Flag != value))
				{
					this.OnDel_FlagChanging(value);
					this.SendPropertyChanging();
					this._Del_Flag = value;
					this.SendPropertyChanged("Del_Flag");
					this.OnDel_FlagChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Update_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Update_Date
		{
			get
			{
				return this._Update_Date;
			}
			set
			{
				if ((this._Update_Date != value))
				{
					this.OnUpdate_DateChanging(value);
					this.SendPropertyChanging();
					this._Update_Date = value;
					this.SendPropertyChanged("Update_Date");
					this.OnUpdate_DateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblPlace")]
	public partial class tblPlace : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Text;
		
		private int _Parent;
		
		private short _Type;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    partial void OnParentChanging(int value);
    partial void OnParentChanged();
    partial void OnTypeChanging(short value);
    partial void OnTypeChanged();
    #endregion
		
		public tblPlace()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Text", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this.OnTextChanging(value);
					this.SendPropertyChanging();
					this._Text = value;
					this.SendPropertyChanged("Text");
					this.OnTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Parent", DbType="Int NOT NULL")]
		public int Parent
		{
			get
			{
				return this._Parent;
			}
			set
			{
				if ((this._Parent != value))
				{
					this.OnParentChanging(value);
					this.SendPropertyChanging();
					this._Parent = value;
					this.SendPropertyChanged("Parent");
					this.OnParentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="SmallInt NOT NULL")]
		public short Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblUser")]
	public partial class tblUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _AccountId;
		
		private string _DisplayName;
		
		private string _FirstName;
		
		private string _LastName;
		
		private int _Gender;
		
		private System.Nullable<System.DateTime> _DateOfBirth;
		
		private string _Address;
		
		private int _CityId;
		
		private int _DistrictId;
		
		private int _VillageId;
		
		private string _Avatar;
		
		private string _PhoneNumber;
		
		private string _Description;
		
		private int _State;
		
		private int _Update_By;
		
		private System.Nullable<System.DateTime> _Update_Date;
		
		private bool _Del_Flag;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnAccountIdChanging(int value);
    partial void OnAccountIdChanged();
    partial void OnDisplayNameChanging(string value);
    partial void OnDisplayNameChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnGenderChanging(int value);
    partial void OnGenderChanged();
    partial void OnDateOfBirthChanging(System.Nullable<System.DateTime> value);
    partial void OnDateOfBirthChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnCityIdChanging(int value);
    partial void OnCityIdChanged();
    partial void OnDistrictIdChanging(int value);
    partial void OnDistrictIdChanged();
    partial void OnVillageIdChanging(int value);
    partial void OnVillageIdChanged();
    partial void OnAvatarChanging(string value);
    partial void OnAvatarChanged();
    partial void OnPhoneNumberChanging(string value);
    partial void OnPhoneNumberChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnStateChanging(int value);
    partial void OnStateChanged();
    partial void OnUpdate_ByChanging(int value);
    partial void OnUpdate_ByChanged();
    partial void OnUpdate_DateChanging(System.Nullable<System.DateTime> value);
    partial void OnUpdate_DateChanged();
    partial void OnDel_FlagChanging(bool value);
    partial void OnDel_FlagChanged();
    #endregion
		
		public tblUser()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountId", DbType="Int NOT NULL")]
		public int AccountId
		{
			get
			{
				return this._AccountId;
			}
			set
			{
				if ((this._AccountId != value))
				{
					this.OnAccountIdChanging(value);
					this.SendPropertyChanging();
					this._AccountId = value;
					this.SendPropertyChanged("AccountId");
					this.OnAccountIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DisplayName", DbType="NVarChar(200)")]
		public string DisplayName
		{
			get
			{
				return this._DisplayName;
			}
			set
			{
				if ((this._DisplayName != value))
				{
					this.OnDisplayNameChanging(value);
					this.SendPropertyChanging();
					this._DisplayName = value;
					this.SendPropertyChanged("DisplayName");
					this.OnDisplayNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(200)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(200)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="Int NOT NULL")]
		public int Gender
		{
			get
			{
				return this._Gender;
			}
			set
			{
				if ((this._Gender != value))
				{
					this.OnGenderChanging(value);
					this.SendPropertyChanging();
					this._Gender = value;
					this.SendPropertyChanged("Gender");
					this.OnGenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateOfBirth", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateOfBirth
		{
			get
			{
				return this._DateOfBirth;
			}
			set
			{
				if ((this._DateOfBirth != value))
				{
					this.OnDateOfBirthChanging(value);
					this.SendPropertyChanging();
					this._DateOfBirth = value;
					this.SendPropertyChanged("DateOfBirth");
					this.OnDateOfBirthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(2000)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityId", DbType="Int NOT NULL")]
		public int CityId
		{
			get
			{
				return this._CityId;
			}
			set
			{
				if ((this._CityId != value))
				{
					this.OnCityIdChanging(value);
					this.SendPropertyChanging();
					this._CityId = value;
					this.SendPropertyChanged("CityId");
					this.OnCityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DistrictId", DbType="Int NOT NULL")]
		public int DistrictId
		{
			get
			{
				return this._DistrictId;
			}
			set
			{
				if ((this._DistrictId != value))
				{
					this.OnDistrictIdChanging(value);
					this.SendPropertyChanging();
					this._DistrictId = value;
					this.SendPropertyChanged("DistrictId");
					this.OnDistrictIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VillageId", DbType="Int NOT NULL")]
		public int VillageId
		{
			get
			{
				return this._VillageId;
			}
			set
			{
				if ((this._VillageId != value))
				{
					this.OnVillageIdChanging(value);
					this.SendPropertyChanging();
					this._VillageId = value;
					this.SendPropertyChanged("VillageId");
					this.OnVillageIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Avatar", DbType="NVarChar(MAX)")]
		public string Avatar
		{
			get
			{
				return this._Avatar;
			}
			set
			{
				if ((this._Avatar != value))
				{
					this.OnAvatarChanging(value);
					this.SendPropertyChanging();
					this._Avatar = value;
					this.SendPropertyChanged("Avatar");
					this.OnAvatarChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhoneNumber", DbType="NVarChar(20)")]
		public string PhoneNumber
		{
			get
			{
				return this._PhoneNumber;
			}
			set
			{
				if ((this._PhoneNumber != value))
				{
					this.OnPhoneNumberChanging(value);
					this.SendPropertyChanging();
					this._PhoneNumber = value;
					this.SendPropertyChanged("PhoneNumber");
					this.OnPhoneNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(MAX)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_State", DbType="Int NOT NULL")]
		public int State
		{
			get
			{
				return this._State;
			}
			set
			{
				if ((this._State != value))
				{
					this.OnStateChanging(value);
					this.SendPropertyChanging();
					this._State = value;
					this.SendPropertyChanged("State");
					this.OnStateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Update_By", DbType="Int NOT NULL")]
		public int Update_By
		{
			get
			{
				return this._Update_By;
			}
			set
			{
				if ((this._Update_By != value))
				{
					this.OnUpdate_ByChanging(value);
					this.SendPropertyChanging();
					this._Update_By = value;
					this.SendPropertyChanged("Update_By");
					this.OnUpdate_ByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Update_Date", DbType="DateTime")]
		public System.Nullable<System.DateTime> Update_Date
		{
			get
			{
				return this._Update_Date;
			}
			set
			{
				if ((this._Update_Date != value))
				{
					this.OnUpdate_DateChanging(value);
					this.SendPropertyChanging();
					this._Update_Date = value;
					this.SendPropertyChanged("Update_Date");
					this.OnUpdate_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Del_Flag", DbType="Bit NOT NULL")]
		public bool Del_Flag
		{
			get
			{
				return this._Del_Flag;
			}
			set
			{
				if ((this._Del_Flag != value))
				{
					this.OnDel_FlagChanging(value);
					this.SendPropertyChanging();
					this._Del_Flag = value;
					this.SendPropertyChanged("Del_Flag");
					this.OnDel_FlagChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
