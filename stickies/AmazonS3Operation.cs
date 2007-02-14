// Copyright 2007 Bret Taylor
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may
// not use this file except in compliance with the License. You may obtain
// a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations
// under the License.

using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Stickies {
  /// <summary>
  /// A network operation with helper methods to send SOAP requests to Amazon's
  /// S3 service. We have convenience methods that use Stickies' default
  /// bucket name (since all sticky notes go in a single bucket).
  /// </summary>
  public abstract class AmazonS3Operation : NetworkOperation {
    private static string AMAZON_TIMESTAMP_FORMAT = "yyyy-MM-dd\\THH:mm:ss.fff\\Z";
    private static string AMAZON_SERVICE_NAME = "AmazonS3";

    protected SynchronizationSettings settings_;
    protected AmazonS3 s3_;

    protected AmazonS3Operation(SynchronizationSettings settings) {
      settings_ = settings;
      s3_ = new AmazonS3();
    }

    protected string GetBucketName() {
      return settings_.AmazonAccessKeyId + "-" + Application.ProductName + "-1";
    }

    protected CreateBucketResult CreateBucket() {
      return CreateBucket(GetBucketName());
    }

    protected CreateBucketResult CreateBucket(string name) {
      DateTime timestamp = GetTimestamp();
      string signature = MakeSignature("CreateBucket", timestamp);
      return s3_.CreateBucket(name, null, settings_.AmazonAccessKeyId, timestamp, true, signature);
    }

    protected ListBucketResult ListBucket() {
      return ListBucket(GetBucketName());
    }

    protected ListBucketResult ListBucket(string bucket) {
      DateTime timestamp = GetTimestamp();
      string signature = MakeSignature("ListBucket", timestamp);
      return s3_.ListBucket(bucket, null, null, 0, false, null, settings_.AmazonAccessKeyId, timestamp, true, signature, null);
    }

    protected GetObjectResult GetObject(string key) {
      return GetObject(GetBucketName(), key);
    }

    protected GetObjectResult GetObject(string bucket, string key) {
      DateTime timestamp = GetTimestamp();
      string signature = MakeSignature("GetObject", timestamp);
      return s3_.GetObject(bucket, key, false, true, true, settings_.AmazonAccessKeyId, timestamp, true, signature, null); 
    }

    protected PutObjectResult PutObject(string key, byte[] data) {
      return PutObject(GetBucketName(), key, data);
    }

    protected PutObjectResult PutObject(string bucket, string key, byte[] data) {
      DateTime timestamp = GetTimestamp();
      string signature = MakeSignature("PutObjectInline", timestamp);
      return s3_.PutObjectInline(bucket, key, null, data, data.Length, null, StorageClass.STANDARD, false, settings_.AmazonAccessKeyId, timestamp, true, signature, null);
    }

    protected Status DeleteObject(string key) {
      return DeleteObject(GetBucketName(), key);
    }

    protected Status DeleteObject(string bucket, string key) {
      DateTime timestamp = GetTimestamp();
      string signature = MakeSignature("DeleteObject", timestamp);
      return s3_.DeleteObject(bucket, key, settings_.AmazonAccessKeyId, timestamp, true, signature, null);
    }

    protected string MakeSignature(string method, DateTime timestamp) {
      string formattedTimestamp = timestamp.ToUniversalTime().ToString(AMAZON_TIMESTAMP_FORMAT, System.Globalization.CultureInfo.InvariantCulture);
      string canonicalString = AMAZON_SERVICE_NAME + method + formattedTimestamp;
      Encoding utf8 = new UTF8Encoding();
      HMACSHA1 signature = new HMACSHA1(utf8.GetBytes(settings_.AmazonSecretAccessKey));
      return Convert.ToBase64String(signature.ComputeHash(utf8.GetBytes(canonicalString.ToCharArray())));
    }

    public static DateTime GetTimestamp() {
      DateTime dateTime = DateTime.Now;
      return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond, DateTimeKind.Local);
    }
  }
}
