﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Azure.StorageServices {
  public class StorageServiceClient {
    private string account;

    public string Account {
      get {
        return account;
      }
    }

    private byte[] key;

    public byte[] Key {
      get {
        return key;
      }
    }

    // https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/versioning-for-the-azure-storage-services
    private string version;

    public string Version {
      get {
        return version;
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Unity3dAzure.StorageServices.StorageServiceClient"/> class.
    /// </summary>
    /// <param name="account">Storage account name.</param>
    /// <param name="accessKey">Access key.</param>
    public StorageServiceClient(string account, string accessKey, string version = "2016-05-31") {
      this.account = account;
      this.key = Convert.FromBase64String(accessKey);
      this.version = version;
    }

    public string PrimaryEndpoint() {
      return "https://" + account + ".blob.core.windows.net/";
    }

    public string SecondaryEndpoint() {
      return "https://" + account + "-secondary.blob.core.windows.net/";
    }

    public BlobService GetBlobService() {
      return new BlobService(this);
    }

  }
}
