using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        //Property
        
        /*
         * Dictionarys:
         * <dataset UUID, dataset>
         * <key of reference keyField, List of Monitored fields >
         * <Monitored field, List of conditions>
         * <condition, List of notifications>
         */

        /*
         * IASS_Dictionary: A dictionary of datasets
         */
        Dictionary<String, Dataset> IASS_Dictionary = new Dictionary<string, Dataset>();



        //Method
        static void Main(string[] args)
        {
            //This is the main program
        }
    }
}
