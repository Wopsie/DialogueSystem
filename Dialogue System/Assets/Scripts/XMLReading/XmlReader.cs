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

        //ReadSubnodes(fileName, path, node, id);

        return nodes[id].SelectSingleNode(node).FirstChild.Value;

        /*
        string charNameAtribute = nodes[i].SelectSingleNode("@name").Value;
        string charName = nodes[i].SelectSingleNode("Name").FirstChild.Value;
        */
    }

    public int ReadSubnodes(string fileName, string path, int id)
    {
        var textFile = Resources.Load(fileName) as TextAsset;

        //load xml into memory
        XmlDocument xmlDoc = new XmlDocument();
        string xml = textFile.text;
        xmlDoc.LoadXml(xml);

        //start parsing xml
        XmlNodeList nodes = xmlDoc.SelectNodes(path);
        XmlNodeList subnodes = nodes[id].SelectNodes("Response");

        for (int i = 0; i < subnodes.Count; i++)
        {
            Debug.Log(subnodes[i].FirstChild.Value);
        }

        return subnodes.Count;
    }
}
