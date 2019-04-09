// Decompiled with JetBrains decompiler
// Type: SmartPing.SR
// Assembly: SmartPing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D8F6303A-2BE2-44FB-A4CE-22A895490C57
// Assembly location: C:\Users\brpea\Source\Repos\pingtracer\PingTest\PingTest\include\SmartPing.dll

using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SmartPing
{
	internal static class SR
	{
		public const string net_inasync = "An asynchronous call is already in progress. It must be completed or canceled before you can call this method.";
		public const string net_invalid_ip_addr = "IPv4 address 0.0.0.0 and IPv6 address ::0 are unspecified addresses that cannot be used as a target address.";
		public const string net_InvalidAddressFamily = "The AddressFamily {0} is not valid for the {1} end point, use {2} instead.";
		public const string net_invalidPingBufferSize = "The buffer length must not exceed 65500 bytes.";
		public const string net_InvalidSocketAddressSize = "The supplied {0} is an invalid size for the {1} end point.";
		public const string net_ipv4_not_installed = "IPv4 is not installed.";
		public const string net_ipv6_not_installed = "IPv6 is not installed.";
		public const string net_ping = "An exception occurred during a Ping request.";
		public const string net_ping_utility_not_found = "The system's ping utility could not be found.";

		private static ResourceManager s_resourceManager;

		private static ResourceManager ResourceManager
			=> s_resourceManager ?? (s_resourceManager = new ResourceManager("SmartPing.Strings", Assembly.GetExecutingAssembly()));

		// This method is used to decide if we need to append the exception message parameters to the message when calling SR.Format.
		// by default it returns false.
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool UsingResourceKeys()
		{
			return false;
		}

		internal static string GetResourceString(string resourceKey, string defaultString)
		{
			string resourceString = null;
			try { resourceString = ResourceManager.GetString(resourceKey); }
			catch (MissingManifestResourceException) { }

			if (defaultString != null && resourceKey.Equals(resourceString, StringComparison.Ordinal))
			{
				return defaultString;
			}

			return resourceString;
		}

		internal static string Format(string resourceFormat, params object[] args)
		{
			if (args != null)
			{
				if (UsingResourceKeys())
				{
					return resourceFormat + string.Join(", ", args);
				}

				return string.Format(resourceFormat, args);
			}

			return resourceFormat;
		}

		internal static string Format(string resourceFormat, object p1)
		{
			if (UsingResourceKeys())
			{
				return string.Join(", ", resourceFormat, p1);
			}

			return string.Format(resourceFormat, p1);
		}

		internal static string Format(string resourceFormat, object p1, object p2)
		{
			if (UsingResourceKeys())
			{
				return string.Join(", ", resourceFormat, p1, p2);
			}

			return string.Format(resourceFormat, p1, p2);
		}

		internal static string Format(string resourceFormat, object p1, object p2, object p3)
		{
			if (UsingResourceKeys())
			{
				return string.Join(", ", resourceFormat, p1, p2, p3);
			}

			return string.Format(resourceFormat, p1, p2, p3);
		}
	}
}
