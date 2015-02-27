using System;
using SQLite;

namespace XamarinMaps
{

	[Table("LocationDataPoint")]
	public class LocationDataPoint
	{

		public LocationDataPoint ()
		{
		}

		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id { get; set; }

		public double Longitude { get;  set;}
		public double Latitude  { get;  set;}


		public DateTime aDateTime { get;  set;}

	}
}

