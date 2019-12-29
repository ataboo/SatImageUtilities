using System;
using System.Threading.Tasks;
using System.Xml;

namespace SatImageUtilities.Tile {
    public static class XmlReaderExtensions {
        /// <summary>
        /// Read until reaching an end-element matching the endName, invoding the nodeAction on each node.
        /// </summary>
        public static async Task ReadToNodeEnd(this XmlReader reader, string endName, Func<XmlReader, Task> nodeAction) {
            while(!reader.EOF) {
                await reader.ReadAsync();
                await nodeAction.Invoke(reader);

                if (reader.NodeType == XmlNodeType.EndElement && reader.LocalName == endName) {
                    break;
                }
            }
        }
    }
}