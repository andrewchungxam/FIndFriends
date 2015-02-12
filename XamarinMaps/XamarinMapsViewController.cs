using System;
using System.Drawing;

using Foundation;
using UIKit;
using MapKit;
using CoreLocation;

using System.Linq;
using System.Collections.Generic;

namespace XamarinMaps
{
	public partial class XamarinMapsViewController : UIViewController
	{
		MKMapView map;
		CLLocationManager locationManager;
//		MyMapDelegate mapDel;
		List<LocationDataPoint> locationHistory; 

		public XamarinMapsViewController (IntPtr handle) : base (handle)
		{
			locationHistory = new List<LocationDataPoint> ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			map = new MKMapView (UIScreen.MainScreen.Bounds);
			map.MapType = MKMapType.Standard;

			locationManager = new CLLocationManager ();
			locationManager.RequestWhenInUseAuthorization ();
			locationManager.RequestAlwaysAuthorization ();
			map.ShowsUserLocation = true;
			this.View = map;


			double userLat;
			double userLon;

			//QUESTION - how do I get the user's latitude? 
//			userLat = map.UserLocation.Coordinate.Latitude;
			userLat = locationManager.Location.Coordinate.Latitude;
			//QUESTION - how do I get the user's longitute?
			//		userLon = map.UserLocation.Coordinate.Longitude;
			userLon = locationManager.Location.Coordinate.Longitude;
//			userLon = map.UserLocation.Coordinate.Longitude;


//			//-20150130 - let's center the view
//			double lat = 42.374260;
//			double lon = -71.120824;
//			var mapCenter = new CLLocationCoordinate2D (lat, lon);
			var mapCenter = new CLLocationCoordinate2D (userLat, userLon);

			var mapRegion = MKCoordinateRegion.FromDistance (mapCenter, 2000, 2000);
			map.CenterCoordinate = mapCenter;
			map.Region = mapRegion;


			//store that location into the List<LocationDataPoint> locationHistory; 
			LocationDataPoint aDataPoint;
			aDataPoint = new LocationDataPoint () 
			{ 
				Latitude = userLat, 
				Longitude = userLon, 
				aDateTime = DateTime.Now 
			};

			locationHistory.Add (aDataPoint);
			Console.WriteLine ("Time {0}, Lat {1}, Lon {2}", aDataPoint.aDateTime, aDataPoint.Latitude, aDataPoint.Longitude);



			//-20150130 - let's center the view
	//		var mapCenter = new CLLocationCoordinate2D (userLat, userLon);
	//		var mapRegion = MKCoordinateRegion.FromDistance (mapCenter, 2000, 2000);
	//		map.CenterCoordinate = mapCenter;
	//		map.Region = mapRegion;


			//let's do some annotations - don't forget the class-level declarations

//			// add an annotation
//			map.AddAnnotation (new MKPointAnnotation () {
//				Title = "MyAnnotation", 
//				Coordinate = new CLLocationCoordinate2D (42.364260, -71.120824)
//			});
//
//			// set the map delegate
//			mapDel = new MyMapDelegate ();
//			map.Delegate = mapDel;
//
//			// add a custom annotation
//			map.AddAnnotation (new MonkeyAnnotation ("Xamarin", mapCenter));

			// add an overlay
//			var circleOverlay = MKCircle.Circle (mapCenter, 1000);
//			map.AddOverlay (circleOverlay);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	}
	//another class declaration

//	class MyMapDelegate : MKMapViewDelegate
//	{
//		string pId = "PinAnnotation";
//		string mId = "MonkeyAnnotation";
//
//		public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, NSObject annotation)
//		{
//			MKAnnotationView anView;
//
//			if (annotation is MKUserLocation)
//				return null; 
//
//			if (annotation is MonkeyAnnotation) {
//
//				// show monkey annotation
//				anView = mapView.DequeueReusableAnnotation (mId);
//
//				if (anView == null)
//					anView = new MKAnnotationView (annotation, mId);
//
//				anView.Image = UIImage.FromFile ("monkey.png");
//				anView.CanShowCallout = true;
//				anView.Draggable = true;
//				anView.RightCalloutAccessoryView = UIButton.FromType (UIButtonType.DetailDisclosure);
//
//			} else {
//
//				// show pin annotation
//				anView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation (pId);
//
//				if (anView == null)
//					anView = new MKPinAnnotationView (annotation, pId);
//
//				((MKPinAnnotationView)anView).PinColor = MKPinAnnotationColor.Red;
//				anView.CanShowCallout = true;
//			}
//
//			return anView;
//		}
//
//		public override void CalloutAccessoryControlTapped (MKMapView mapView, MKAnnotationView view, UIControl control)
//		{
//			var monkeyAn = view.Annotation as MonkeyAnnotation;
//
//			// what is this notation where you use the "as" ^ (I think it's some type of implicit type conversation)
//
//			if (monkeyAn != null) {
//				var alert = new UIAlertView ("Monkey Annotation", monkeyAn.Title, null, "OK");
//				alert.Show ();
//			}
//		}
//
//		public override MKOverlayView GetViewForOverlay (MKMapView mapView, NSObject overlay)
//		{
//			var circleOverlay = overlay as MKCircle;
//			var circleView = new MKCircleView (circleOverlay);
//			circleView.FillColor = UIColor.Red;
//			circleView.Alpha = 0.4f;
//			return circleView;
//		}
//	} //end class
}

