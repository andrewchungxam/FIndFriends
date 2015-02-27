using System;
using System.IO;
using SQLite;


namespace XamarinMaps
{
	public class DataAccess
	{
		public DataAccess ()
		{
		}

//		public static string DoSomeDataAccess (LocationDataPoint inputDataPoint)
		public static void DoSomeDataAccess (LocationDataPoint inputDataPoint)
		{


			Console.WriteLine ("DataAccess worked!");


			var output = "";
			output += "\nCreating database, if it doesn't already exist";
			string dbPath = Path.Combine (
				Environment.GetFolderPath (Environment.SpecialFolder.Personal), "XamarinMapsLocation.db3");

			var db = new SQLiteConnection (dbPath);
			db.CreateTable<LocationDataPoint> (); // this will probably mess things up
			db.Insert (inputDataPoint);

			if (db.Table<LocationDataPoint> ().Count() == 0) {
				// only insert the data if it doesn't already exist
//								var newStock = new Stock ();
//								newStock.Symbol = "AAPL";
//								db.Insert (newStock); 
//
//								newStock = new Stock ();
//								newStock.Symbol = "GOOG";
//								db.Insert (newStock); 
//
//								newStock = new Stock ();
//								newStock.Symbol = "MSFT";
//								db.Insert (newStock);
			}

						output += "\nReading data using Orm";
			var table = db.Table<LocationDataPoint> ();
						foreach (var s in table) {
				output += "\n" + s.Id + " " + s.Latitude + s.Longitude;

				Console.WriteLine ("Stored Time {0}, Lat {1}, Lon {2}", s.aDateTime, s.Latitude, s.Longitude);

						}

	//					return output;


		}

		public static string MoreComplexQuery () 
		{
			var output = "";
//			output += "\nComplex query example: ";
//			string dbPath = Path.Combine (
//				Environment.GetFolderPath (Environment.SpecialFolder.Personal), "ormdemo.db3");
//
//			var db = new SQLiteConnection (dbPath);
//
//			var query = db.Query<Stock> ("SELECT * FROM [Items] WHERE Symbol = ?", "MSFT");
//			foreach (var s in query) {
//				output += "\n" + s.Id + " " + s.Symbol;
//			}
//
			return output;
		}

		public static string Get () 
		{
			var output = "";
//			output += "\nGet query example: ";
//			string dbPath = Path.Combine (
//				Environment.GetFolderPath (Environment.SpecialFolder.Personal), "ormdemo.db3");
//
//			var db = new SQLiteConnection (dbPath);
//
//			var returned = db.Get<Stock>(3);
//
			return output;
		}

		public static string Delete () 
		{
			var output = "";
//			output += "\nDelete query example: ";
//			string dbPath = Path.Combine (
//				Environment.GetFolderPath (Environment.SpecialFolder.Personal), "ormdemo.db3");
//
//			var db = new SQLiteConnection (dbPath);
//
//			var rowcount = db.Delete(new Stock(){Id=3});
//
			return output;
		}

		public static string ScalarQuery () 
		{
			var output = "";
//			output += "\nScalar query example: ";
//			string dbPath = Path.Combine (
//				Environment.GetFolderPath (Environment.SpecialFolder.Personal), "ormdemo.db3");
//
//			var db = new SQLiteConnection (dbPath);
//
//			var rowcount = db.ExecuteScalar<int> ("SELECT COUNT(*) FROM [Items] WHERE Symbol <> ?", "MSFT");
//
//			output += "\nNumber of rows : " + rowcount;
//
			return output;
		}


	}
}

