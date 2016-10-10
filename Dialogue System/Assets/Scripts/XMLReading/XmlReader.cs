using UnityEngine;
using System.Collections;
using System.Xml;

public class XmlReader{

    public string ReadXml(string fileName, string path, string node, int id)
    {
        /*
        WHEN LOADING FROM RESOURCES, DO NOT INCLUDE FILE EXTENSION IN NAME
        */

        var textFile = Resources.Load(fileName) as TextAsset;
        
        //load xml into memory
        XmlDocument xmlDoc = new XmlDocument();
        string xml = textFile.text;
        xmlDoc.LoadXml(xml);

        //start parsing xml
        string charactersxPath = path;
        XmlNodeList nodes = xmlDoc.SelectNodes(charactersxPath);

        return nodes[id].SelectSingleNode(node).FirstChild.Value;

        /*
        string charNameAtribute = nodes[i].SelectSingleNode("@name").Value;
        string charName = nodes[i].SelectSingleNode("Name").FirstChild.Value;
        */
    }
}
