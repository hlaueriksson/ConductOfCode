﻿//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v8.5.6214.25340 (NJsonSchema v7.3.6214.20986) (http://NSwag.org)
// </auto-generated>
//----------------------

namespace ConductOfCode.Specs.Clients
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "8.5.6214.25340")]
    public partial class StackClient 
    {
        private string _baseUrl = "http://localhost:5000";
        
        public string BaseUrl 
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }
    
        partial void PrepareRequest(System.Net.Http.HttpClient request, ref string url);
    
        partial void ProcessResponse(System.Net.Http.HttpClient request, System.Net.Http.HttpResponseMessage response);
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ClearAsync()
        {
            return ClearAsync(System.Threading.CancellationToken.None);
        }
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ClearAsync(System.Threading.CancellationToken cancellationToken)
        {
            var url_ = string.Format("{0}/{1}", BaseUrl, "api/Stack/Clear");
    
            using (var client_ = new System.Net.Http.HttpClient())
            {
                var request_ = new System.Net.Http.HttpRequestMessage();
                PrepareRequest(client_, ref url_);
                var content_ = new System.Net.Http.StringContent(string.Empty);
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);
                ProcessResponse(client_, response_);
    
                var responseData_ = await response_.Content.ReadAsByteArrayAsync().ConfigureAwait(false); 
                var status_ = ((int)response_.StatusCode).ToString();
    
                if (status_ == "204") 
                {
                    return;
                }
                else
                if (status_ != "200" && status_ != "204")
                    throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, null);
            }
        }
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Item> PeekAsync()
        {
            return PeekAsync(System.Threading.CancellationToken.None);
        }
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Item> PeekAsync(System.Threading.CancellationToken cancellationToken)
        {
            var url_ = string.Format("{0}/{1}", BaseUrl, "api/Stack/Peek");
    
            using (var client_ = new System.Net.Http.HttpClient())
            {
                var request_ = new System.Net.Http.HttpRequestMessage();
                PrepareRequest(client_, ref url_);
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);
                ProcessResponse(client_, response_);
    
                var responseData_ = await response_.Content.ReadAsByteArrayAsync().ConfigureAwait(false); 
                var status_ = ((int)response_.StatusCode).ToString();
    
                if (status_ == "200") 
                {
                    var result_ = default(Item); 
                    try
                    {
                        if (responseData_.Length > 0)
                            result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Item>(System.Text.Encoding.UTF8.GetString(responseData_, 0, responseData_.Length));                                
                        return result_; 
                    } 
                    catch (System.Exception exception) 
                    {
                        throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, exception);
                    }
                }
                else
                if (status_ == "400") 
                {
                    var result_ = default(Error); 
                    try
                    {
                        if (responseData_.Length > 0)
                            result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(System.Text.Encoding.UTF8.GetString(responseData_, 0, responseData_.Length));                                
                    } 
                    catch (System.Exception exception) 
                    {
                        throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, exception);
                    }
                    throw new SwaggerException<Error>("A server side error occurred.", status_, responseData_, result_, null);
                }
                else
                if (status_ != "200" && status_ != "204")
                    throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, null);
            
                return default(Item);
            }
        }
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Item> PopAsync()
        {
            return PopAsync(System.Threading.CancellationToken.None);
        }
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Item> PopAsync(System.Threading.CancellationToken cancellationToken)
        {
            var url_ = string.Format("{0}/{1}", BaseUrl, "api/Stack/Pop");
    
            using (var client_ = new System.Net.Http.HttpClient())
            {
                var request_ = new System.Net.Http.HttpRequestMessage();
                PrepareRequest(client_, ref url_);
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);
                ProcessResponse(client_, response_);
    
                var responseData_ = await response_.Content.ReadAsByteArrayAsync().ConfigureAwait(false); 
                var status_ = ((int)response_.StatusCode).ToString();
    
                if (status_ == "200") 
                {
                    var result_ = default(Item); 
                    try
                    {
                        if (responseData_.Length > 0)
                            result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Item>(System.Text.Encoding.UTF8.GetString(responseData_, 0, responseData_.Length));                                
                        return result_; 
                    } 
                    catch (System.Exception exception) 
                    {
                        throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, exception);
                    }
                }
                else
                if (status_ == "400") 
                {
                    var result_ = default(Error); 
                    try
                    {
                        if (responseData_.Length > 0)
                            result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(System.Text.Encoding.UTF8.GetString(responseData_, 0, responseData_.Length));                                
                    } 
                    catch (System.Exception exception) 
                    {
                        throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, exception);
                    }
                    throw new SwaggerException<Error>("A server side error occurred.", status_, responseData_, result_, null);
                }
                else
                if (status_ != "200" && status_ != "204")
                    throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, null);
            
                return default(Item);
            }
        }
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task PushAsync(Item item)
        {
            return PushAsync(item, System.Threading.CancellationToken.None);
        }
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task PushAsync(Item item, System.Threading.CancellationToken cancellationToken)
        {
            var url_ = string.Format("{0}/{1}", BaseUrl, "api/Stack/Push");
    
            using (var client_ = new System.Net.Http.HttpClient())
            {
                var request_ = new System.Net.Http.HttpRequestMessage();
                PrepareRequest(client_, ref url_);
                var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(item));
                content_.Headers.ContentType.MediaType = "application/json";
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);
                ProcessResponse(client_, response_);
    
                var responseData_ = await response_.Content.ReadAsByteArrayAsync().ConfigureAwait(false); 
                var status_ = ((int)response_.StatusCode).ToString();
    
                if (status_ == "204") 
                {
                    return;
                }
                else
                if (status_ != "200" && status_ != "204")
                    throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, null);
            }
        }
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Item>> ToArrayAsync()
        {
            return ToArrayAsync(System.Threading.CancellationToken.None);
        }
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Item>> ToArrayAsync(System.Threading.CancellationToken cancellationToken)
        {
            var url_ = string.Format("{0}/{1}", BaseUrl, "api/Stack/ToArray");
    
            using (var client_ = new System.Net.Http.HttpClient())
            {
                var request_ = new System.Net.Http.HttpRequestMessage();
                PrepareRequest(client_, ref url_);
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);
                ProcessResponse(client_, response_);
    
                var responseData_ = await response_.Content.ReadAsByteArrayAsync().ConfigureAwait(false); 
                var status_ = ((int)response_.StatusCode).ToString();
    
                if (status_ == "200") 
                {
                    var result_ = default(System.Collections.ObjectModel.ObservableCollection<Item>); 
                    try
                    {
                        if (responseData_.Length > 0)
                            result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Item>>(System.Text.Encoding.UTF8.GetString(responseData_, 0, responseData_.Length));                                
                        return result_; 
                    } 
                    catch (System.Exception exception) 
                    {
                        throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, exception);
                    }
                }
                else
                if (status_ != "200" && status_ != "204")
                    throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, null);
            
                return default(System.Collections.ObjectModel.ObservableCollection<Item>);
            }
        }
    
    }
    
    

    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "7.3.6214.20986")]
    public partial class Item : System.ComponentModel.INotifyPropertyChanged
    { 
        private string _value;
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Value
        {
            get { return _value; }
            set 
            {
                if (_value != value)
                {
                    _value = value; 
                    RaisePropertyChanged();
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static Item FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Item>(data);
        }
        
        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
    
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "7.3.6214.20986")]
    public partial class Error : System.ComponentModel.INotifyPropertyChanged
    { 
        private string _message;
    
        [Newtonsoft.Json.JsonProperty("Message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message
        {
            get { return _message; }
            set 
            {
                if (_message != value)
                {
                    _message = value; 
                    RaisePropertyChanged();
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static Error FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(data);
        }
        
        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "8.5.6214.25340")]
    public class SwaggerException : System.Exception
    {
        public string StatusCode { get; private set; }

        public byte[] ResponseData { get; private set; }

        public SwaggerException(string message, string statusCode, byte[] responseData, System.Exception innerException) 
            : base(message, innerException)
        {
            StatusCode = statusCode;
            ResponseData = responseData;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: n{0}n{1}", System.Text.Encoding.UTF8.GetString(ResponseData, 0, ResponseData.Length), base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "8.5.6214.25340")]
    public class SwaggerException<TResponse> : SwaggerException
    {
        public TResponse Response { get; private set; }

        public SwaggerException(string message, string statusCode, byte[] responseData, TResponse response, System.Exception innerException) 
            : base(message, statusCode, responseData, innerException)
        {
            Response = response;
        }
    }

}