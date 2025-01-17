﻿using System;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;

namespace Core.Utilities.Results.Concrete;

public class DataResult<T> : IDataResult<T>
{
	public DataResult(ResultStatus resultStatus, T data)
	{
		ResultStatus = resultStatus;
		Data = data;
	}

	public DataResult(ResultStatus resultStatus, string message, T data)
	{
		ResultStatus = resultStatus;
		Message = message;
		Data = data;
	}

	public DataResult(ResultStatus resultStatus, string message, T data, Exception exception)
	{
		ResultStatus = resultStatus;
		Message = message;
		Data = data;
		Exception = exception;
	}

	public ResultStatus ResultStatus { get; }
	public string Message { get; }
	public Exception Exception { get; set; }
	public T Data { get; }
}