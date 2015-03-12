using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Dictionary
{
    class Program
    {
        //Property

        /*
         * Dictionarys:
         * DatasetDictionary <dataset UUID, dataset>
         * <key of reference keyField, List of Monitored fields >
         * <Monitored field, List of conditions>
         * <condition, List of notifications>
         */

        /*
         * DatasetDictionary IASS_Dictionary: A dictionary of datasets
         * <given UUID of a dataset, retrieved dataset object>
         * Operations:
         * {
         *      1. get dataset by UUID (public)
         *      getDatasetByUUID [input: String UUID, output: Dataset object with the UUID];
         *      
         *      2. add new dataset to dictionary (operate by IASS)
         *      addDataset [input: Dataset structure, 
         *                  output: a boolean value 
         *                          true-successfully add the dataset,
         *                          false-failed to add the dataset];
         * 
         *      3. delete dataset from dictionary (operate by IASS)
         *      deleteDataset [input: Dataset structure, 
         *                     output: a boolean value 
         *                             true-successfully remove the dataset,
         *                             false-failed to remove the dataset];
         * 
         *      4. list all dataset in the dictionary (public)
         *      listAllDatasets() [input: void, 
         *                         output:void (but all datasets will be printed out)]
         *      5. get the list of 
         *         current monitored <key in referenced field, field> pairs(public)
         *      getCurrentMonitorList[input: String UUID,
         *                            output: List of <key, field> pair]
         *      
         * }
         */

        //Method
        static void Main(string[] args)
        {
            //This is the main program
            String folderPath = ".\testSets";
            DatasetDictionary IASS_Dictionary = new DatasetDictionary(folderPath);

            Console.WriteLine("\nFinish adding\n\n");

            Console.WriteLine("=======list all in Dictionary after add========\n\n");

            IASS_Dictionary.listAllDatasets();

            Console.WriteLine("\ntry deleting\n\n");

            IASS_Dictionary.deleteDataset("83f6087b316a63177fd03443ad7421bd");

            Console.WriteLine("------list all in Dictionary after delete-------\n\n");

            IASS_Dictionary.listAllDatasets();

            //add get 
            Thread.Sleep(50000); 

        }
    }
}
