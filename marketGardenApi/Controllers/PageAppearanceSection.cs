using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace marketGardenApi.Controllers
{
	public class MarketGetterConfig : ConfigurationSection
	{

	[ConfigurationProperty("markets", IsDefaultCollection = false)]
	[ConfigurationCollection(typeof(MarketCollection),
			   AddItemName = "add",
			   ClearItemsName = "clear",
			   RemoveItemName = "remove")]
		public MarketCollection Market
		{
			get
			{
				return (MarketCollection)this["markets"];
			}
			set
			{ this["markets"] = value; }
		}
	}


	public class MarketCollection : ConfigurationElementCollection
	{
		public void Add(MarketElement serviceConfig)
		{
			BaseAdd(serviceConfig);
		}

		public void Clear()
		{
			BaseClear();
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new MarketElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((MarketElement)element).AltCurrency;
		}

		public void Remove(MarketElement serviceConfig)
		{
			BaseRemove(serviceConfig.AltCurrency);
		}

		public void RemoveAt(int index)
		{
			BaseRemoveAt(index);
		}

		public void Remove(string name)
		{
			BaseRemove(name);
		}

	}

	public class MarketElement: ConfigurationElement
	{
		[ConfigurationProperty("baseCurrency", IsRequired = true)]
		public string BaseCurrency
		{
			get { return (string)this["baseCurrency"]; }
			set { this["baseCurrency"] = value; }
		}

		[ConfigurationProperty("altCurrency", IsRequired = true)]
		public string AltCurrency
		{
			get { return (string)this["altCurrency"]; }
			set { this["altCurrency"] = value; }
		}

		[ConfigurationProperty("thresholdPercent", IsRequired = true)]
		public double ThresholdPercent
		{
			get { return (double)this["thresholdPercent"]; }
			set { this["thresholdPercent"] = value; }
		}

		[ConfigurationProperty("readers", IsDefaultCollection = false)]
		[ConfigurationCollection(typeof(ReaderCollection),
				   AddItemName = "add",
				   ClearItemsName = "clear",
				   RemoveItemName = "remove")]
		
		public ReaderCollection ReadersCollection
		{
			get { return (ReaderCollection)this["readers"]; }
			set { this["readers"] = value; }
		}


	}

	public class ReaderCollection : ConfigurationElementCollection
	{
		public void Add(ReaderElement serviceConfig)
		{
			BaseAdd(serviceConfig);
		}

		public void Clear()
		{
			BaseClear();
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new ReaderElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ReaderElement)element).Type;
		}

		public void Remove(ReaderElement serviceConfig)
		{
			BaseRemove(serviceConfig.Type);
		}

		public void RemoveAt(int index)
		{
			BaseRemoveAt(index);
		}

		public void Remove(string name)
		{
			BaseRemove(name);
		}
	}
	public class ReaderElement : ConfigurationElement
	{
		[ConfigurationProperty("type", IsRequired = true)]
		public string Type
		{
			get { return (string)this["type"]; }
			set { this["type"] = value; }
		}
	}
}