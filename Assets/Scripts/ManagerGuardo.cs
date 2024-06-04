using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
//using Unity.Android.Gradle.Manifest;

public class ManagerGuardo : MonoBehaviour
{
    [System.Obsolete]
    public static ManagerGuardo Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(ManagerGuardo)) as ManagerGuardo;
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    private static ManagerGuardo instance;
    public string saveFileName = "/BraceForImpactSave.sav";
    public Data[] objectToSave;

    private void Awake()
    {
        Load();
    }
    public void Save()
    {
        JObject jSaveGame = new JObject();

        foreach (Data data in objectToSave)
        {
            Data currentData = data;
            JObject serializedData = currentData.Serialize();
            jSaveGame.Add(currentData.name, serializedData);
        }
        string saveFilePath = UnityEngine.Application.persistentDataPath + saveFileName;

        byte[] encryptSavegame = Encrypt(jSaveGame.ToString());
        File.WriteAllBytes(saveFilePath, encryptSavegame);

        Debug.Log("Saving to: " + saveFilePath);
    }

    public void Load()
    {
        string saveFilePath = UnityEngine.Application.persistentDataPath + saveFileName;
        Debug.Log("Loading from: " + saveFilePath);
        byte[] decryptedSavegame = File.ReadAllBytes(saveFilePath);
        string jsonString = Decrypt(decryptedSavegame);
        JObject jSaveGame = JObject.Parse(jsonString);

        foreach (Data data in objectToSave)
        {
            Data currentData = data;
            string dataJsonString = jSaveGame[currentData.name].ToString();
            currentData.Deserialize(dataJsonString);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    /*PARA ENCRIPTAR Y DESENCRIPTAR LA INFORMACIÓN DEL ARCHIVO DE GUARDADO
    */

    //Clave generada para la encriptación en formato bytes, 16 posiciones
    byte[] _key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
    //Vector de inicialización para la clave
    byte[] _initializationVector = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

    //Encriptamos los datos del archivo de guardado que le pasaremos en un string
    byte[] Encrypt(string message)
    {
        //Usamos esta librería que nos permitirá a través de una referencia crear un encriptador de la información
        AesManaged aes = new AesManaged();
        //Para usar este encriptador le pasamos tanto la clave como el vector de inicialización que hemos creado nosotros arriba
        ICryptoTransform encryptor = aes.CreateEncryptor(_key, _initializationVector);
        //Lugar en memoria donde guardamos la información encriptada
        MemoryStream memoryStream = new MemoryStream();
        //Con esta referencia podremos escribir en el MemoryStream de arriba la información ya encriptada usando el encriptador con sus claves que ya habíamos creado
        CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        //Con el StreamWriter podemos escribir en el archivo la información encriptada, que se habrá guardado en el MemoryStream
        StreamWriter streamWriter = new StreamWriter(cryptoStream);

        //Usando todo lo anterior, guardamos en el archivo de guardado el json que le pasamos por parámetro, haciendo el siguiente proceso: recibimos el string, lo encriptamos, queda guardado en la memoria reservada para la encriptación
        streamWriter.WriteLine(message);

        //Una vez hemos usado estas referencias las cerramos para evitar problemas de guardado o corrupción del archivo o de la propia encriptación
        streamWriter.Close();
        cryptoStream.Close();
        memoryStream.Close();

        //Por último el método devolverá esta información que reside en el hueco de memoria con la información encriptada, convertida esta información en array de bytes
        return memoryStream.ToArray();
    }

    //Generamos un método que nos devuelva la información del archivo de guardado desencriptada
    string Decrypt(byte[] message)
    {
        //Usamos esta librería que nos permitirá a través de una referencia crear un desencriptador de la información
        AesManaged aes = new AesManaged();
        //Para usar este desencriptador le pasamos tanto la clave como el vector de inicialización que hemos creado nosotros arriba
        ICryptoTransform decrypter = aes.CreateDecryptor(_key, _initializationVector);
        //Lugar en memoria donde guardamos la información desencriptada
        MemoryStream memoryStream = new MemoryStream(message);
        //Con esta referencia podremos escribir en el MemoryStream de arriba la información ya desencriptada usando el desencriptador con sus claves que ya habíamos creado
        CryptoStream cryptoStream = new CryptoStream(memoryStream, decrypter, CryptoStreamMode.Read);
        //Con el StreamReader podemos leer del archivo la información desencriptada, que se habrá guardado en el MemoryStream
        StreamReader streamReader = new StreamReader(cryptoStream);

        //Usando todo lo anterior, cargamos del archivo de guardado el json que le pasamos por parámetro, haciendo el siguiente proceso: recibimos el string, lo desencriptamos, queda guardado en la memoria reservada para la desencriptación
        string decryptedMessage = streamReader.ReadToEnd();

        //Una vez hemos usado estas referencias las cerramos para evitar problemas de guardado o corrupción del archivo o de la propia encriptación
        streamReader.Close();
        cryptoStream.Close();
        memoryStream.Close();

        //Por último el método devolverá esta información que reside en el hueco de memoria con la información desencriptada, convertida esta en un string
        return decryptedMessage;
    }
}