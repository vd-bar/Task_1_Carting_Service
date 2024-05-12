namespace Common.Result
{
    public class ResultInfo
    {
        #region Properties

        public string Message { get; set; }
        public bool Success { get; set; }
        public int Code { get; set; }

        #endregion
    }

    public class ResultInfo<T> : ResultInfo
    {

        #region Properties
        public T Value { get; set; }

        #endregion
    }

    public class ResultInfo<TSuccess, TError> : ResultInfo
    {
        #region Properties

        public TSuccess Value { get; set; }
        public TError ErrorValue { get; set; }

        #endregion
    }

    public class ResultInfoCode : ResultInfo
    {
        #region Properties

        public int ResultCode { get; set; }

        #endregion
    }

    public class ResultInfoCode<T> : ResultInfoCode
    {
        #region Properties

        public T Value { get; set; }

        #endregion
    }
}