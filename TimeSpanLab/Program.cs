using System;

using WizardWrx;
using WizardWrx.ConsoleAppAids3;
using WizardWrx.Core;

namespace TimeSpanLab
{
    class Program
    {
        static ConsoleAppStateManager s_stateManager = ConsoleAppStateManager.GetTheSingleInstance ( );

        static void Main ( string [ ] args )
        {
            s_stateManager.DisplayBOJMessage ( );

            s_stateManager.BaseStateManager.AppExceptionLogger.OptionFlags = s_stateManager.BaseStateManager.AppExceptionLogger.OptionFlags
                                                                             | WizardWrx.DLLConfigurationManager.ExceptionLogger.OutputOptions.NBSpaceForNewlines
                                                                             | WizardWrx.DLLConfigurationManager.ExceptionLogger.OutputOptions.StandardError
                                                                             | WizardWrx.DLLConfigurationManager.ExceptionLogger.OutputOptions.Stack
                                                                             | WizardWrx.DLLConfigurationManager.ExceptionLogger.OutputOptions.Source
                                                                             | WizardWrx.DLLConfigurationManager.ExceptionLogger.OutputOptions.Method
                                                                             | WizardWrx.DLLConfigurationManager.ExceptionLogger.OutputOptions.EventLog;

            try
			{
                DateTime dateTime1 = new DateTime ( 2020 , 6 , 12 , 1 , 23 , 0 );
                DateTime dateTime2 = new DateTime ( 2020 , 6 , 12 , 4 , 44 , 0 );

                TimeSpan timeSpan1 = new TimeSpan ( dateTime2.TimeOfDay.Ticks - dateTime1.TimeOfDay.Ticks );

                ShowDateTime (
                    dateTime1 ,
                    nameof ( dateTime1 ) );
                ShowDateTime (
                    dateTime2 ,
                    nameof ( dateTime2 ) );
                ShowTimeOfDay (
                    timeSpan1 ,
                    nameof ( timeSpan1 ) );
			}
            catch ( Exception exAll )
            {
                s_stateManager.BaseStateManager.AppExceptionLogger.ReportException ( exAll );
                s_stateManager.BaseStateManager.AppReturnCode = MagicNumbers.ERROR_RUNTIME;
            }

            if ( s_stateManager.BaseStateManager.AppReturnCode == MagicNumbers.ERROR_SUCCESS )
            {
                s_stateManager.NormalExit ( ConsoleAppStateManager.NormalExitAction.WaitForOperator );
            }   // TRUE (anticipated outcome) block, if ( s_stateManager.BaseStateManager.AppReturnCode == MagicNumbers.ERROR_SUCCESS )
            else
            {
                s_stateManager.ErrorExit ( ( uint ) s_stateManager.BaseStateManager.AppReturnCode );
            }   // FALSE (unanticipated outcome) block, if ( s_stateManager.BaseStateManager.AppReturnCode == MagicNumbers.ERROR_SUCCESS )
        }   // static void Main

		private static void ShowDateTime (
            DateTime pdtm ,
            string pstrVariableName )
		{
            Console.WriteLine (
                @"{2}Properties of {0} variable {1}:{2}" ,
                pdtm.GetType ( ).FullName ,
                pstrVariableName ,
                Environment.NewLine );
            Console.WriteLine ( @"    Year        = {0}" , pdtm.Year );
            Console.WriteLine ( @"    Month       = {0}" , pdtm.Month );
            Console.WriteLine ( @"    Day         = {0}{1}" , pdtm.Day , Environment.NewLine );
            Console.WriteLine ( @"    DayOfWeek   = {0}" , pdtm.DayOfWeek );
            Console.WriteLine ( @"    DayOfYear   = {0}{1}" , pdtm.DayOfYear , Environment.NewLine );
            Console.WriteLine ( @"    Hour        = {0}" , pdtm.Hour );
            Console.WriteLine ( @"    Minute      = {0}" , pdtm.Minute );
            Console.WriteLine ( @"    Second      = {0}{1}" , pdtm.Second , Environment.NewLine );
            Console.WriteLine ( @"    Millisecond = {0}" , pdtm.Millisecond );
            Console.WriteLine ( @"    Ticks       = {0}{1}" , pdtm.Ticks , Environment.NewLine );

            ShowTimeOfDay (
                pdtm.TimeOfDay ,
                nameof ( pdtm.TimeOfDay ) ,
                false );
        }   // private static void ShowDateTime

        private static void ShowTimeOfDay (
            TimeSpan pts ,
            string pstrVariableName ,
            bool pfLeadWithNewline = true )
        {
            Console.WriteLine (
                @"{3}Properties of {0} variable {1}:{2}" ,
                pts.GetType ( ).FullName ,
                pstrVariableName ,
                Environment.NewLine ,
                pfLeadWithNewline ? Environment.NewLine : string.Empty );
            Console.WriteLine ( @"    Day               = {0}" , pts.Days );
            Console.WriteLine ( @"    Hours             = {0}" , pts.Hours );
            Console.WriteLine ( @"    Minutes           = {0}" , pts.Minutes );
            Console.WriteLine ( @"    Seconds           = {0}" , pts.Seconds );
            Console.WriteLine ( @"    Milliseconds      = {0}{1}" , pts.Milliseconds , Environment.NewLine );
            Console.WriteLine ( @"    Ticks             = {0}{1}" , pts.Ticks , Environment.NewLine );
            Console.WriteLine ( @"    TotalDays         = {0}" , pts.TotalDays );
            Console.WriteLine ( @"    TotalHours        = {0}" , pts.TotalHours );
            Console.WriteLine ( @"    TotalMinutes      = {0}" , pts.TotalMinutes );
            Console.WriteLine ( @"    TotalSeconds      = {0}" , pts.TotalSeconds );
            Console.WriteLine ( @"    TotalMilliseconds = {0}" , pts.TotalMilliseconds );
        }   // private static void ShowTimeOfDay
    }   // class Program
}   // amespace TimeSpanLab