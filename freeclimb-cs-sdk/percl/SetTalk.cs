﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using com.freeclimb.api;

namespace com.freeclimb.percl
{
    /// <summary>
    /// SetTalk PerCL command.
    /// </summary>
    [JsonObject]
    public sealed class SetTalk : PerCLCommand
    {
        [JsonProperty(PropertyName = "callId")]
        private string callId = string.Empty;

        [JsonProperty(PropertyName = "talk")]
        private EBool talk = EBool.NONE;

        /// <summary>
        /// Helper method to build a JSON string from a SetTalk instance.
        /// </summary>
        /// <returns>A JSON string equivalent to the SetTalk instance.</returns>
        /// <exception cref="FreeClimbJSONException">Thrown upon deserialize failure.</exception>
        public override string toJson()
        {
            try
            {
                JsonSerializer jsonSerializer = JsonSerializer.Create();
                jsonSerializer.NullValueHandling = NullValueHandling.Ignore;

                StringBuilder strb = new StringBuilder();
                jsonSerializer.Serialize(new StringWriter(strb), toKvp());

                return strb.ToString();
            }
            catch (Exception e)
            {
                throw new FreeClimbJSONException(e.Message);
            }
        }

        /// <summary>
        /// Creates SetTalk PerCL with require fields. 
        /// </summary>
        /// <param name="callId">Call Id.</param>
        public SetTalk(string callId)
        {
            this.callId = callId;
        }

        /// <summary>
        /// Retrieve the callId value.
        /// </summary>
        /// <returns>The callId value of the object.</returns>
        public string getCallId { get { return this.callId; } }

        /// <summary>
        /// Set the callId value.
        /// </summary>
        /// <param name="val">callId value.</param>
        public void setCallId(string val) { this.callId = val; }

        /// <summary>
        /// Retrieve value.
        /// </summary>
        /// <returns>The value of the object.</returns>
        /// <see cref="EBool">Bool enumeration.</see>
        public EBool getTalk { get { return this.talk; } }

        /// <summary>
        /// Set value.
        /// </summary>
        /// <param name="val">value.</param>
        /// <see cref="EBool">Bool enumeration.</see>
        public void setTalk(EBool val) { this.talk = val; }

        /// <summary>
        /// Retrieve the KVP Dictionary for the SetTalk instance. 
        /// </summary>
        /// <returns>KVP Dictionary</returns>
        /// <exception cref="FreeClimbJSONException">Thrown upon deserialize failure.</exception>
        public override IDictionary<string, object> toKvp()
        {
            // change all properties with settings to a dictionary
            IDictionary<string, object> props = new Dictionary<string, object>();

            if (this.callId == string.Empty)
            {
                throw new FreeClimbJSONException("callId is a required parameter");
            }
            props.Add("callId", this.callId);

            if (this.talk == EBool.NONE)
            {
                EnumMemberAttribute attr = EnumHelper.GetAttributeOfType<EnumMemberAttribute>(EBool.True);
                props.Add("talk", bool.Parse(attr.Value));
            }
            else
            {
                EnumMemberAttribute attr = EnumHelper.GetAttributeOfType<EnumMemberAttribute>(this.talk);
                props.Add("talk", bool.Parse(attr.Value));
            }

            IDictionary<string, object> command = new Dictionary<string, object>();
            command.Add("SetTalk", props);

            return command;
        }
    }
}
