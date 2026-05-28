using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using diseasePrediction.DataLayerTableAdapters;
using System.Data;

namespace diseasePrediction
{
    public class BLL
    {
        tblUsersTableAdapter userObj = new tblUsersTableAdapter();
        tblParametersTableAdapter parameterObj = new tblParametersTableAdapter();
        tblTrainingDatasetTableAdapter datasetObj = new tblTrainingDatasetTableAdapter();
        tblTestingDatasetTableAdapter testingObj = new tblTestingDatasetTableAdapter();
        tblActualDatasetTableAdapter actualObj = new tblActualDatasetTableAdapter();
        tblTreatmentTableAdapter treatmentObj = new tblTreatmentTableAdapter();
        tblNewPatientsTableAdapter newpatientObj = new tblNewPatientsTableAdapter();

        //login module

        //function to check the user login id and password(admin,doctor/rece)
        public DataTable CheckUserLogin(string userId, string password)
        {
            return userObj.CheckUserLogin(userId, password);
        }

        //User change Password
        public void UpdateUserPassword(string password, string userId)
        {
            userObj.UpdateUserPassword(password, userId);
        }

        //User management

        //function to insert new User
        public void InsertUser(string userId, string password, string userType, string emailId)
        {
            userObj.InsertUser(userId, password, userType, emailId);
        }

        //function to delete the user
        public void DeleteUser(string userId)
        {
            userObj.DeleteUser(userId);
        }

        //function to get other users(doc and rece)
        public DataTable GetOtherUsers()
        {
            return userObj.GetOtherUsers();
        }

        //function to retrive all users based on type
        public DataTable GetUsersByType(string userType)
        {
            return userObj.GetUsersByUserType(userType);
        }

        //function to check the userid
        public bool CheckUserId(string userId)
        {
            int cnt = int.Parse(userObj.CheckUserId(userId).ToString());

            if (cnt == 1)

                return false;

            return true;
        }


        //function to get the user by id
        public DataTable GetUserById(string userId)
        {
            return userObj.GetUserById(userId);
        }

        //function to update the user
        public void UpdateUser(string userId, string password, string type, string emailId, string UId)
        {
            userObj.UpdateUser(userId, password, type, emailId, UId);
        }

      
        //manage parameters

        //function to check the parameter
        public bool CheckParameter(string parameter)
        {
            int cnt = int.Parse(parameterObj.CheckParameter(parameter).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to insert new parameter
        public void InsertParameter(string parameter)
        {
            parameterObj.InsertParameter(parameter);
        }

        //function to update parameter
        public void UpdateParameter(string parameter, int parameterId)
        {
            parameterObj.UpdateParameter(parameter, parameterId);
        }

        //function to delete parameter
        public void DeleteParameter(int parameterId)
        {
            parameterObj.DeleteParameter(parameterId);
        }

        //function to get the parameter based on id
        public DataTable GetParameterById(int parameterId)
        {
            return parameterObj.GetParameterById(parameterId);
        }

        //function to retrive all parameters
        public DataTable GetAllParameters()
        {
            return parameterObj.GetData();
        }

        //manage dataset

        //function to get all training dataset
        public DataTable GetTrainingDataset()
        {
            return datasetObj.GetData();
        }

       //function to insert training data
        public void InsertTrainingData(string name, int Age, double BP, double SG, double AL, double Sugar, double redbloodcells,
                                        double PusCell, double PusCellClumps, double Bacteria, double BloodGlucoseRandom, double BloodUrea,
                                        double SerumCreatinine, double Sodium, double Potassium, double Hemoglobin,
                                        double PackedCellVolume, double WhiteBloodCellCount, double RedBloodCellCount, double Hypertension,
                                        double DiabetesMellitus, double CoronaryArteryDisease, double Appetite, double PedalEdema,
                                        double Anemia, int Result)
        {
            datasetObj.InsertTrainingData(name, Age, BP, SG, AL, Sugar, redbloodcells, PusCell, PusCellClumps, Bacteria, BloodGlucoseRandom, BloodUrea,
                                          SerumCreatinine, Sodium, Potassium, Hemoglobin, PackedCellVolume, WhiteBloodCellCount, RedBloodCellCount, Hypertension,
                                          DiabetesMellitus, CoronaryArteryDisease, Appetite, PedalEdema, Anemia, Result);
        }

        //function to update training data
        public void UpdateTrainingData(string name, int Age, double BP, double SG, double AL, double Sugar, double redbloodcells,
                                        double PusCell, double PusCellClumps, double Bacteria, double BloodGlucoseRandom, double BloodUrea,
                                        double SerumCreatinine, double Sodium, double Potassium, double Hemoglobin,
                                        double PackedCellVolume, double WhiteBloodCellCount, double RedBloodCellCount, double Hypertension,
                                        double DiabetesMellitus, double CoronaryArteryDisease, double Appetite, double PedalEdema,
                                        double Anemia, int Result, int datasetId)
        {
            datasetObj.UpdateTrainingData(name, Age, BP, SG, AL, Sugar, redbloodcells, PusCell, PusCellClumps, Bacteria, BloodGlucoseRandom, BloodUrea,
                                          SerumCreatinine, Sodium, Potassium, Hemoglobin, PackedCellVolume, WhiteBloodCellCount, RedBloodCellCount, Hypertension,
                                          DiabetesMellitus, CoronaryArteryDisease, Appetite, PedalEdema, Anemia, Result, datasetId);
        }

        //function to delete training data
        public void DeleteTrainingData(int datasetId)
        {
            datasetObj.DeleteTrainingData(datasetId);
        }

        //function to fetch training data by id
        public DataTable GetTrainingDataById(int Id)
        {
            return datasetObj.GetTrainingDataById(Id);
        }

        //manage testing dataset

        //function to get all testing dataset
        public DataTable GetTestingDataset()
        {
            return testingObj.GetData();
        }

        //function to insert testing data
        public void InsertTestingData(string name, int Age, double BP, double SG, double AL, double Sugar, double redbloodcells,
                                        double PusCell, double PusCellClumps, double Bacteria, double BloodGlucoseRandom, double BloodUrea,
                                        double SerumCreatinine, double Sodium, double Potassium, double Hemoglobin,
                                        double PackedCellVolume, double WhiteBloodCellCount, double RedBloodCellCount, double Hypertension,
                                        double DiabetesMellitus, double CoronaryArteryDisease, double Appetite, double PedalEdema,
                                        double Anemia)
        {
            testingObj.InsertTestingData(name, Age, BP, SG, AL, Sugar, redbloodcells, PusCell, PusCellClumps, Bacteria, BloodGlucoseRandom, BloodUrea,
                                          SerumCreatinine, Sodium, Potassium, Hemoglobin, PackedCellVolume, WhiteBloodCellCount, RedBloodCellCount, Hypertension,
                                          DiabetesMellitus, CoronaryArteryDisease, Appetite, PedalEdema, Anemia);
        }

        //function to update testing data
        public void UpdateTestingData(string name, int Age, double BP, double SG, double AL, double Sugar, double redbloodcells,
                                        double PusCell, double PusCellClumps, double Bacteria, double BloodGlucoseRandom, double BloodUrea,
                                        double SerumCreatinine, double Sodium, double Potassium, double Hemoglobin,
                                        double PackedCellVolume, double WhiteBloodCellCount, double RedBloodCellCount, double Hypertension,
                                        double DiabetesMellitus, double CoronaryArteryDisease, double Appetite, double PedalEdema,
                                        double Anemia,
                                        int datasetId)
        {
            testingObj.UpdateTestingData(name, Age, BP, SG, AL, Sugar, redbloodcells, PusCell, PusCellClumps, Bacteria, BloodGlucoseRandom, BloodUrea,
                                          SerumCreatinine, Sodium, Potassium, Hemoglobin, PackedCellVolume, WhiteBloodCellCount, RedBloodCellCount, Hypertension,
                                          DiabetesMellitus, CoronaryArteryDisease, Appetite, PedalEdema, Anemia, datasetId);
        }

        //function to delete the testing data
        public void DeleteTestingData(int testingDataId)
        {
            testingObj.DeleteTestingData(testingDataId);
        }

        //function to fetch testing data by id
        public DataTable GetTestingDataById(int Id)
        {
            return testingObj.GetTestingDataById(Id);
        }


        //function to fetch GetActualPatientDataById
        public DataTable GetActualPatientDataById(int patId)
        {
           return actualObj.GetActualPatientDataById(patId);
        }

        //function to get actual cnt
        public int GetActualCnt()
        {
            return (int)actualObj.GetActualCnt();
        }

        //function to retirve all treatmentdetails
        public DataTable GetAllTreatments()
        {
            return treatmentObj.GetData();
        }

        public DataTable GetTreatmentByPatientId(int patientId)
        {
            return treatmentObj.GetTreatmentByPatientId(patientId);
        }

        //function to insert the treatment details
        public void InsertTreatment(int patientId, string treatment, DateTime date)
        {
            treatmentObj.InsertTreatment(patientId, treatment, date);
        }

        //function to delete the treatment details
        public void DeleteTreatment(int treatmentId)
        {
            treatmentObj.DeleteTreatment(treatmentId);
        }

        //function to get the treatment details by Ids
        public DataTable GetTreatmentByid(int treatmentId)
        {
            return treatmentObj.GetTreatmentById(treatmentId);
        }

        //function to update the treatment details
        public void UpdateTreatment(int patientId, string treatment, DateTime date, int treatmentId)
        {
            treatmentObj.UpdateTreatment(patientId, treatment, date, treatmentId);
        }

       

        //newpatientObj
        public void InsertNewPatient(int age, string name, string mobile, string address)
        {
            newpatientObj.InsertNewPatient(age, name, mobile, address);
        }

        //update new patient
        public void UpdateNewPatient(int age, string name, string mobile, string address, int pId)
        {
            newpatientObj.UpdateNewPatient(age, name, mobile, address, pId);
        }

        //get all new patients
        public DataTable GetAllNewPatients()
        {
            return newpatientObj.GetData();
        }

        //function to get new patient by id
        public DataTable GetNewPatientById(int pid)
        {
            return newpatientObj.GetNewPatientById(pid);
        }

        //function to delete new patient
        public void DeleteNewPatient(int pid)
        {
            newpatientObj.DeleteNewPatient(pid);
        }

        //function to delete new patient treatment
        public void DeleteTreatmentByNewPatient(int pid)
        {
            treatmentObj.DeleteTreatmentByPId(pid);
        }

        public bool CheckPatientLogin(int userId, int pwd)
        {
            int cnt = int.Parse(newpatientObj.CheckPatientLogin(userId, pwd).ToString());

            if (cnt == 1)

                return true;

            return false;
        }
    }
}