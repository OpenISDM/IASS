using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Dataset_Dictionary
    {
        //This class is the dictionary of IASS which is a dictionary about datasets
        //property

        /*
         * <given UUID of a dataset, retrieved dataset object>
         */
        Dictionary<String, Dataset> datasetDictionary = new Dictionary<String, Dataset>();

        //Constructor
        public Dataset_Dictionary()
        {
            //Debug information
            Console.WriteLine("An IASS dictionary was created");
            
            //Exception
            /*
             * Not constructed successfully
             */
        }

        //Method
        public Dataset getDatasetByUUID(String UUID)
        {
            /*
             * passing the specified UUID to this function
             * to retrieve the dataset from Dictionary
             */

            //Debug information
            Console.WriteLine("An IASS dictionary was created");

            //find Dataset with specified UUID in dictionary
            if (datasetDictionary.ContainsKey(UUID) == true)
            {
                //If the dataset with specific UUID was found
                return datasetDictionary[UUID];
            }
            else
            {
                //If it was not found, deal with exception and return null
                return null;
            }

        }
    }
}
