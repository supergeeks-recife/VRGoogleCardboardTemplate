using UnityEngine;
using System.IO.Ports;

public class ArduinoIntegration : MonoBehaviour
{
    public string portName = "COM4"; // Porta serial do Arduino
    public int baudRate = 9600; // Taxa de transmissão

    private SerialPort serialPort;

    private void Start()
    {
        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open();
    }

    private void Update()
    {
        if (serialPort.IsOpen)
        {
            string message = serialPort.ReadLine();

            if(Input.GetKeyDown(KeyCode.Space))
                Debug.Log("Botão do Arduino pressionado");

            /*
            if (message.Contains("Botão pressionado"))
            {
                Debug.Log("Botão do Arduino pressionado");
            }
            */
        }
    }

    private void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
