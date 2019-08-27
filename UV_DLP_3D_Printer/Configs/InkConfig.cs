using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using UV_DLP_3D_Printer.Configs;
using System.Drawing;

namespace UV_DLP_3D_Printer.Configs
{
    public class InkConfig
    {
        public string Name; // name of this ink setting
        public double ZThick; // thickness of the z layer - slicing height
        public int layertime_ms; // time to project image per layer in milliseconds
        public int firstlayertime_ms; // first layer exposure time 
        public int numfirstlayers;
        public double resinprice; // per liter
        public Color ForeColor; // foreground and background color makes much more sense to be in the ink config / slciing parameters.
        public Color BackColor;

        public InkConfig(string name)
        {
            Name = name;
            ZThick = 0.05;
            layertime_ms = 1000;
            firstlayertime_ms = 5000;
            numfirstlayers = 3;
            resinprice = 0.0; // per liter
        }

        public void CopyFrom(InkConfig otherInk)
        {
            ZThick = otherInk.ZThick;
            layertime_ms = otherInk.layertime_ms;
            firstlayertime_ms = otherInk.firstlayertime_ms;
            numfirstlayers = otherInk.numfirstlayers;
            resinprice = otherInk.resinprice; // per liter
        }

        public bool Load(XmlHelper xh, XmlNode xnode)
        {
            Name = xh.GetString(xnode, "Name", "Default");
            ZThick = xh.GetDouble(xnode, "SliceHeight", 0.05);
            layertime_ms = xh.GetInt(xnode, "LayerTime", 1000); 
            firstlayertime_ms = xh.GetInt(xnode, "FirstLayerTime", 5000);
            numfirstlayers = xh.GetInt(xnode, "NumberofBottomLayers", 3);
            resinprice = xh.GetDouble(xnode, "ResinPriceL", 0.0);
            return true;
        }
        public bool Save(XmlHelper xh, XmlNode parent)
        {
            XmlNode xnode = xh.AddSection(parent, "InkConfig");
            xh.SetParameter(xnode, "Name", Name);
            xh.SetParameter(xnode, "SliceHeight", ZThick);
            xh.SetParameter(xnode, "LayerTime", layertime_ms);
            xh.SetParameter(xnode, "FirstLayerTime", firstlayertime_ms);
            xh.SetParameter(xnode, "NumberofBottomLayers", numfirstlayers);
            xh.SetParameter(xnode, "ResinPriceL", resinprice);
            return true;
        }
    }


    public class PowderConfig
    {
        public string name; // name of this ink setting
        public double price; // per liter

        public PowderConfig(string name)
        {
            this.name = name;
            price = 0.0; // per liter
        }

        public void CopyFrom(PowderConfig powder)
        {
            price = powder.price; // per liter
        }

        public bool Load(XmlHelper xh, XmlNode xnode)
        {
            name = xh.GetString(xnode, "Name", "Default");
            price = xh.GetDouble(xnode, "PriceL", 0.0);
            return true;
        }
        public bool Save(XmlHelper xh, XmlNode parent)
        {
            XmlNode xnode = xh.AddSection(parent, "PowderConfig");
            xh.SetParameter(xnode, "Name", name);
            xh.SetParameter(xnode, "PriceL", price);
            return true;
        }
    }


    public class FluidConfig
    {
        public string name; // name of this ink setting
        public double price; // per liter

        public FluidConfig(string name)
        {
            this.name = name;
            price = 0.0; // per liter
        }

        public void CopyFrom(FluidConfig powder)
        {
            price = powder.price; // per liter
        }

        public bool Load(XmlHelper xh, XmlNode xnode)
        {
            name = xh.GetString(xnode, "Name", "Default");
            price = xh.GetDouble(xnode, "PriceL", 0.0);
            return true;
        }
        public bool Save(XmlHelper xh, XmlNode parent)
        {
            XmlNode xnode = xh.AddSection(parent, "FluidConfig");
            xh.SetParameter(xnode, "Name", name);
            xh.SetParameter(xnode, "PriceL", price);
            return true;
        }
    }
}
