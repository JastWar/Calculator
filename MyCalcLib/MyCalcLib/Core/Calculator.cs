﻿using System;
using CalculatorLib.CommonTypes;
using System.Collections.Generic;

namespace CalculatorLib.Core
{
	public class Calculator
	{
	    private const int POW2 = 2;
        private const int POW3 = 3;
		
		private Dictionary<OperationType, Func<Arguments, double>> operationsDic = new Dictionary<OperationType, Func<Arguments, double>>
		{
			{ OperationType.Sum, args => args.A + args.B },
			{ OperationType.Sub, args => args.A - args.B },
			{ OperationType.Mul, args => args.A * args.B },
			{ OperationType.Div, args => args.A / args.B },
			{ OperationType.Mod, args => args.A % args.B },
			{ OperationType.Sqrt, args => Math.Sqrt(args.A) },
			{ OperationType.Pow2, args => Math.Pow(args.A, POW2) },
			{ OperationType.Pow3, args => Math.Pow(args.A, POW3) }
		};

		public Func<Arguments,double> GetFunk(OperationType operationType)
		{
			try
			{
				Func<Arguments, double> funk = operationsDic[operationType];
				return funk;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Wrong Operation");
				Func<Arguments, double> funk = null;
				return funk;
			}
		}

		public void AddOperation(OperationType operationType, Func<Arguments, double> value )
		{
			operationsDic.Add(operationType, value);
		}

		public void RemoveOperation(OperationType operationType)
		{
			operationsDic.Remove(operationType);
		}
	}
}
