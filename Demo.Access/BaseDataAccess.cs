using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace demo.DataAccess
{
    public class BaseDataAccess
    {
        #region Declaration
        private SqlConnection _conn = null;
        private SqlCommand _command = null;
        private SqlTransaction _trans = null;
        private SqlDataAdapter _adapter = null;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Public Properties
        public List<SqlParameter> DBParameters { get; set; }



        public virtual string ConString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["AskMeBazaarConnection"].ConnectionString;
            }
        }
        public virtual string ReadConString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["AskMeBazaarConnection"].ConnectionString;
            }
        }
        public SqlTransaction Transaction { get { return _trans; } }
        #endregion

        #region Constructor
        public BaseDataAccess()
        {
            DBParameters = new List<SqlParameter>();
            log4net.Config.XmlConfigurator.Configure();
        }

        public BaseDataAccess(BaseDataAccess baseAccess)
        {
            DBParameters = new List<SqlParameter>();
            this._conn = baseAccess._conn;
            this._trans = baseAccess._trans;
            this._adapter = baseAccess._adapter;
        }
        #endregion

        #region Public Methods

        protected DataSet ExecuteDataSet(string spName)
        {
            try
            {
                DataSet recordsDs = new DataSet();
                _command = _conn.CreateCommand();
                _command.CommandTimeout = 600;
                _command.CommandText = spName;
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddRange(DBParameters.ToArray());

                if (_adapter == null)
                    _adapter = new SqlDataAdapter();
                _adapter.SelectCommand = _command;
                _adapter.Fill(recordsDs);

                return recordsDs;

            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("ExecuteDataSet: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("ExecuteDataSet: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }
        }

        protected IDataReader ExecuteReader(string spName, int read)
        {
            try
            {
                if (_conn == null)
                {
                    OpenConnection(read);
                }
                _command = _conn.CreateCommand();
                _command.CommandTimeout = 600;
                _command.CommandText = spName;
                _command.CommandType = CommandType.StoredProcedure;

                _command.Parameters.AddRange(DBParameters.ToArray());
                return _command.ExecuteReader();

            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("ExecuteReader: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("ExecuteReader: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw;
            }
        }
        protected IDataReader ExecuteReader(string spName)
        {
            try
            {
                if (_conn == null)
                {
                    OpenConnection();
                }
                _command = _conn.CreateCommand();
                _command.CommandTimeout = 600;
                _command.CommandText = spName;
                _command.CommandType = CommandType.StoredProcedure;

                _command.Parameters.AddRange(DBParameters.ToArray());
                return _command.ExecuteReader();

            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("ExecuteReader: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("ExecuteReader: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw;
            }
        }

        protected object ExecuteScalar(string spName, int read)
        {
            try
            {
                if (_conn == null)
                {
                    OpenConnection(read);
                }
                _command = _conn.CreateCommand();
                _command.CommandText = spName;
                _command.CommandTimeout = 600;
                _command.CommandType = CommandType.StoredProcedure;

                _command.Parameters.AddRange(DBParameters.ToArray());
                return _command.ExecuteScalar();

            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("ExecuteScalar: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("ExecuteScalar: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }
        }
        protected object ExecuteScalar(string spName)
        {
            try
            {
                if (_conn == null)
                {
                    OpenConnection();
                }
                _command = _conn.CreateCommand();
                _command.CommandText = spName;
                _command.CommandTimeout = 600;
                _command.CommandType = CommandType.StoredProcedure;

                _command.Parameters.AddRange(DBParameters.ToArray());
                return _command.ExecuteScalar();

            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("ExecuteScalar: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("ExecuteScalar: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }
        }
        protected object ExecuteNonQuery(string spName, int read)
        {
            try
            {
                if (_conn == null)
                {
                    OpenConnection(read);
                }
                _command = _conn.CreateCommand();
                _command.CommandText = spName;
                _command.CommandTimeout = 600;
                _command.CommandType = CommandType.StoredProcedure;

                _command.Parameters.AddRange(DBParameters.ToArray());
                return _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("ExecuteNonQuery: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("ExecuteNonQuery: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }
        }
        protected object ExecuteNonQuery(string spName)
        {
            try
            {
                if (_conn == null)
                {
                    OpenConnection();
                }
                _command = _conn.CreateCommand();
                _command.CommandText = spName;
                _command.CommandTimeout = 600;
                _command.CommandType = CommandType.StoredProcedure;

                _command.Parameters.AddRange(DBParameters.ToArray());
                return _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("ExecuteNonQuery: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("ExecuteNonQuery: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }
        }

        #endregion

        #region Parameters

        protected void AddParameter(string name, object value)
        {
            DBParameters.Add(new SqlParameter(name, value));
        }

        protected void AddParameter(string name, object value, ParameterDirection direction)
        {
            SqlParameter parameter = new SqlParameter(name, value);
            parameter.Direction = direction;
            DBParameters.Add(parameter);
        }

        protected object GetOutParameterValue(string parameterName)
        {
            if (_command != null)
            {
                return _command.Parameters[parameterName].Value;
            }
            return null;
        }
        #endregion

        #region SaveData
        protected bool SaveData(string spName, int read)
        {
            try
            {
                if (_conn == null)
                {
                    OpenConnection(read);
                }
                _command = _conn.CreateCommand();
                _command.CommandTimeout = 600;
                _command.CommandText = spName;
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddRange(DBParameters.ToArray());

                int result = _command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("SaveData: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("SaveData: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }
        }
        protected bool SaveData(string spName)
        {
            try
            {
                if (_conn == null)
                {
                    OpenConnection();
                }
                _command = _conn.CreateCommand();
                _command.CommandTimeout = 600;
                _command.CommandText = spName;
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddRange(DBParameters.ToArray());

                int result = _command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("SaveData: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("SaveData: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }
        }
        #endregion

        #region Transaction Members

        public bool BeginTransaction(int read)
        {
            try
            {
                bool IsOK = this.OpenConnection(read);

                if (IsOK)
                    _trans = _conn.BeginTransaction();
            }
            catch (Exception ex)
            {
                CloseConnection();
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("BeginTransaction: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("BeginTransaction: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }

            return true;
        }
        public bool BeginTransaction()
        {
            try
            {
                bool IsOK = this.OpenConnection();

                if (IsOK)
                    _trans = _conn.BeginTransaction();
            }
            catch (Exception ex)
            {
                CloseConnection();
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("BeginTransaction: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("BeginTransaction: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }

            return true;
        }

        public bool CommitTransaction()
        {
            try
            {
                _trans.Commit();
            }

            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("CommitTransaction: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("CommitTransaction: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
            return true;
        }

        public void RollbackTransaction()
        {
            try
            {
                _trans.Rollback();
            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("RollbackTransaction: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("RollbackTransaction: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
            return;
        }

        public bool OpenConnection()
        {
            try
            {

                if (this._conn == null)
                    _conn = new SqlConnection(ConString);

                if (this._conn.State != ConnectionState.Open)
                {
                    this._conn.Open();
                }

            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("OpenConnection: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("OpenConnection: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }
            return true;
        }
        public bool OpenConnection(int read)
        {
            try
            {

                if (this._conn == null)
                    _conn = new SqlConnection(ReadConString);

                if (this._conn.State != ConnectionState.Open)
                {
                    this._conn.Open();
                }

            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("OpenConnection: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("OpenConnection: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }
            return true;
        }
        public bool CloseConnection()
        {
            try
            {
                if (this._conn.State != ConnectionState.Closed)
                    this._conn.Close();
            }
            catch (Exception ex)
            {
                log.StartMethod();
                if (ex.InnerException != null)
                    log.Error("CloseConnection: " + ex.Message + ex.InnerException + ex.StackTrace.ToString());
                else
                    log.Error("CloseConnection: " + ex.Message + ex.StackTrace.ToString());
                log.EndMethod();
                throw ex;
            }
            finally
            {
                if (_conn != null)
                {
                    _conn.Dispose();
                    this._conn = null;
                }


            }
            return true;
        }

        #endregion

        #region Utility Functions
        protected long GetFieldValue(IDataReader sqlReader, string fieldName, long defaultValue)
        {
            int pos = sqlReader.GetOrdinal(fieldName);
            return sqlReader.IsDBNull(pos) ? 0L : sqlReader.GetInt64(pos);
        }

        protected int GetFieldValue(IDataReader sqlReader, string fieldName, int defaultValue)
        {
            int pos = sqlReader.GetOrdinal(fieldName);
            return sqlReader.IsDBNull(pos) ? 0 : sqlReader.GetInt32(pos);
        }

        protected Guid GetFieldValue(IDataReader sqlReader, string fieldName, Guid defaultValue)
        {
            int pos = sqlReader.GetOrdinal(fieldName);
            return sqlReader.IsDBNull(pos) ? Guid.NewGuid() : (Guid)sqlReader.GetGuid(pos);
        }

        protected float GetFieldValue(IDataReader sqlReader, string fieldName, float defaultValue)
        {
            int pos = sqlReader.GetOrdinal(fieldName);
            //return sqlReader.IsDBNull(pos) ? 0 : sqlReader.GetFloat(pos);
            return sqlReader.IsDBNull(pos) ? 0 : (float)sqlReader.GetDouble(pos);
        }

        //Added on 3-march 
        protected double GetFieldValue(IDataReader sqlReader, string fieldName, double defaultValue)
        {
            int pos = sqlReader.GetOrdinal(fieldName);
            return sqlReader.IsDBNull(pos) ? 0 : sqlReader.GetDouble(pos);
        }
        protected decimal GetFieldValue(IDataReader sqlReader, string fieldName, decimal defaultValue)
        {
            int pos = sqlReader.GetOrdinal(fieldName);
            return sqlReader.IsDBNull(pos) ? 0 : sqlReader.GetDecimal(pos);
        }

        protected string GetFieldValue(IDataReader sqlReader, string fieldName, string defaultValue)
        {
            int pos = sqlReader.GetOrdinal(fieldName);
            return sqlReader.IsDBNull(pos) ? String.Empty : sqlReader.GetString(pos);
        }

        protected DateTime GetFieldValue(IDataReader sqlReader, string fieldName, DateTime defaultValue)
        {
            int pos = sqlReader.GetOrdinal(fieldName);
            return sqlReader.IsDBNull(pos) ? DateTime.MinValue.AddYears(1900) : sqlReader.GetDateTime(pos);
        }
        protected DateTime? GetEndDate(IDataReader sqlReader, string fieldName, DateTime? defaultValue)
        {
            int pos = sqlReader.GetOrdinal(fieldName);
            return sqlReader.IsDBNull(pos) ? DateTime.MinValue.AddYears(2100) : sqlReader.GetDateTime(pos);
        }

        protected bool GetFieldValue(IDataReader sqlReader, string fieldName, bool defaultValue)
        {
            int pos = sqlReader.GetOrdinal(fieldName);
            return sqlReader.IsDBNull(pos) ? false : sqlReader.GetBoolean(pos);
        }
        #endregion
    }
}
