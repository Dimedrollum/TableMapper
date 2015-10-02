using System;
using System.Collections.Generic;

namespace TableMapper
{
	public class Table
	{
		public List<Row> Rows {
			get;
			private set;
		}
		private string filename;

		public Table (string filename)
		{
		}

		public void MapValuesFrom(Table sourseTable)
		{
		}

		public void Save()
		{
		}
	}
}

