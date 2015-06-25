using System;

public struct TimeElapsed
{
	public int hundredths;
	public int seconds;
	public int minutes;


	public static TimeElapsed operator -(TimeElapsed TimeElapsed1, TimeElapsed TimeElapsed2){
		return new TimeElapsed(TimeElapsed1.hundredths - TimeElapsed2.hundredths,
		                             TimeElapsed1.seconds - TimeElapsed2.seconds,
		                             TimeElapsed1.minutes - TimeElapsed2.minutes);

	}

	public static TimeElapsed operator +(TimeElapsed TimeElapsed1, TimeElapsed TimeElapsed2){
		return new TimeElapsed(TimeElapsed1.hundredths + TimeElapsed2.hundredths,
		                             TimeElapsed1.seconds + TimeElapsed2.seconds,
		                             TimeElapsed1.minutes + TimeElapsed2.minutes);
		
	}

	public TimeElapsed (int hundredths, int seconds, int minutes) {
			this.hundredths = hundredths;
		this.seconds = seconds;
		this.minutes = minutes;
	}

	public override string ToString () {
		return String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, hundredths);
	}
	                        
}