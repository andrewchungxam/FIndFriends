using System;
using SQLite;
namespace XamarinMaps
{


	// Create a new table and create a ID for each column.
	[Table("LocationData")]
	public class LocationDataPoint
	{

		public LocationDataPoint ()
		{
		}

		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id { get;  set;}

		public double Longitude { get;  set;}
		public double Latitude  { get;  set;}
		public DateTime aDateTime { get;  set;}

	}
}

