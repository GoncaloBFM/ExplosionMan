using UnityEngine;
using System.Collections;
using System;

public class ConnectionResult {

	public enum ErrorType {None, ElementAlreadyExists, CouldNotConnect ,Default}
	private const char ERROR_FLAG = 'E';
	private const char SUCCESS_FLAG = 'S';

	public ErrorType Error {
		get;
		private set;
	}

	public string Result {
		get;
		private set;
	}
	
	public ConnectionResult(string rawResult) {
		char successFlag = rawResult[0];
		string result = rawResult.Substring(1);
		if (ERROR_FLAG == successFlag) {
			int errorCode = Convert.ToInt32(result);
			switch(errorCode) {
			case 1062:
				Error = ErrorType.ElementAlreadyExists;
				break;
			default:
				Error = ErrorType.Default;
				break;
			}
			Result = null;
		} else if (SUCCESS_FLAG == successFlag) {
			Error = ErrorType.None;
			Result = result;
		}
	}

	public ConnectionResult(ErrorType errorType) {
		Error = errorType;
		Result = null;
	}
}
