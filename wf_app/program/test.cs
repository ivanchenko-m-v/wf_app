namespace test
{
	
	class collection
	{
		public void add(object o)
		{
			//....
		}
		
		public void insert(int i_pos, object o)
		{
			//....
		}

		public void remove(object o)
		{
			//....
		}

    }//class collection

    class program
	{
		static void Main( )
		{
			collection c= new collection( );
			
			program.fill_collection( c );
			//...
			foreach( object o in c )
			{
				//...
			}
		}
		
		private static void fill_collection( collection c )
		{
						//...

		}

    }//class program

}//namespace test

