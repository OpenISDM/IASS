using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Dictionary
{
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
         *                         
         *      5. show the list of current monitored 
         *         <key in referenced field, field> pairs(public)
         *      showCurrentMonitorList[input: String UUID,
         *                            output: void (Show all of <key, field> pairs
         *                                    related to the dataset)]
         *      
         * }
         */
    
    class DatasetDictionary
    {
        //This class is the dictionary of IASS which is a dictionary about datasets
        //property

        /*
         * <given UUID of a dataset, retrieved dataset object>
         */
        Dictionary<String, Dataset> datasetDictionary = new Dictionary<String, Dataset>();

        //Constructor
        public DatasetDictionary(String folderPath)
        {
            //Debug information
            Console.WriteLine("An IASS dictionary was created");
            
            //Method

            /*
             * Initialize datasetDictionary
             */
            initialDictionary(folderPath);

            //Exception
            /*
             * Not constructed successfully
             */
        }

        //Method
        private Boolean initialDictionary(String folderPath)
        {
            //When a datasetdictionary is newed, initialize it
            
            //Debug information
            Console.WriteLine("Thsi dataset dictionary was initialized");
            
            //Property
            //XmlDocument xmlDoc = new XmlDocument();
            
            //open all the dataset files in folderPath
            string[] filePaths = Directory.GetFiles("../../testSets/");
            XmlDocument XmlDoc = new XmlDocument();

            foreach (string onePath in filePaths)
            {

                Dataset newDataset = new Dataset();
                Boolean addSuccess = false;
                //list all files in the folder
                Console.WriteLine("This is the path of {0}", onePath);

                //string temp = "../../testSets/14dd1e924bf344cad0632cec07e79555.xml";
                //XmlDoc.Load(temp);
                XmlDoc.Load(onePath);

                XmlNodeList nodeListOfName = XmlDoc.SelectNodes("Root/dataset_name");
                XmlNodeList nodeListOfUUID = XmlDoc.SelectNodes("Root/uuid");

                foreach (XmlNode OneNode in nodeListOfName)
                {
                    String temporaryName = OneNode.InnerText;
                    newDataset.setDatasetName(temporaryName);
                    Console.WriteLine("dataset name = {0}", temporaryName);
                }

                foreach (XmlNode OneNode in nodeListOfUUID)
                {
                    String temporaryUUID = OneNode.InnerText;
                    newDataset.setDatasetUUID(temporaryUUID);
                    Console.WriteLine("dataset uuid = {0}", temporaryUUID);
                }
                addSuccess = addDataset(newDataset);

            }





            Boolean initialSuccess = false;

            return initialSuccess;
        }
        public Dataset getDatasetByUUID(String UUID)
        {
            /*
             * passing the specified UUID to this function
             * to retrieve the dataset from Dictionary
             */

            //Debug information
            Console.WriteLine("This function is to find the dataset which UUID is {0}",UUID);

            //find Dataset with specified UUID in dictionary
            if (datasetDictionary.ContainsKey(UUID) == true)
            {
                //If the dataset with specific UUID was found
                return datasetDictionary[UUID];
            }
            else
            {
                //Exception
                //If it was not found, deal with exception and return null
                return null;
            }

        }
        public void listAllDatasets()
        {
            //Debug information
            Console.WriteLine("This function is to list all datasets"+
                              "(by keys, list names) in the dictionary");

            // list all datasets in the dictionary
            foreach (var oneItem in datasetDictionary)
            {
                Console.WriteLine("Key = {0}, Value ={1} ",
                                   oneItem.Key,oneItem.Value.getDatasetName());
            }
        }
        public Boolean addDataset(Dataset newDataset)
        {
            //Debug information
            Console.WriteLine("This function will add a new dataset into dictionary");

            //Add a dataset into dictionary
            Boolean addSuccess = true;
            String newDatasetID = newDataset.getDatasetUUID();
            datasetDictionary.Add(newDatasetID, newDataset);
          
            //Exception

            return addSuccess;

        }
        public Boolean deleteDataset(String datasetUUID)
        {
            //Debug information
            Console.WriteLine("This function will delete a dataset from dictionary");

            //Delete a dataset from dictionary
            String obsoleteDatasetID = datasetUUID;
            Boolean deleteSuccess = datasetDictionary.Remove(obsoleteDatasetID);

            //Exception

            return deleteSuccess;
        }
        public void showCurrentMonitorList(String datasetUUID)
        {
            /*
             * This function will list all of the current monitored <key, field> pair
             * of thsi dataset
             */
            
            //Debug information
            Console.WriteLine("This function is to list all monitored fields of the dataset" +
                              "(by keys, list all monitored fields) in the dictionary");

            Dataset specifiedDataset;
            
            //find Dataset with specified UUID in dictionary
            if (datasetDictionary.ContainsKey(datasetUUID) == true)
            {
                //If the dataset with specific UUID was found
                specifiedDataset = datasetDictionary[datasetUUID];
                //Print all monitored fields which related to this dataset
                specifiedDataset.printAllMonitoredFieldList();
            }
            else
            {
                //Exception
                //If it was not found, deal with exception and return null
            }

        }

    }
}
