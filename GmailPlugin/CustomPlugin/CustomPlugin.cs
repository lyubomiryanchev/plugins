using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModernSteward;
using System.Speech.Recognition;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace ModernSteward
{
    public class CustomPlugin : PluginFunctionality
    {
        private CredentialsAsk CredentialForm;
        public string GmailUsername = string.Empty;
        public string GmailPassword = string.Empty;
        public override void Trigger(List<KeyValuePair<string, string>> semanticsToDict)
        {
            GMailIntegration mail = new GMailIntegration("renegat96@gmail.com", "esdcf878");
			if (semanticsToDict[0].Key == "check for new mail") {

			}
        }

        public override GrammarBuilder GetGrammarBuilder()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ModernSteward.CustomPluginGrammar.xml");
            return ModernSteward.TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromXML(stream);
        }

        public override void Initialize()
        {
            //Custom initialization for your plugin
            CredentialForm = new CredentialsAsk();
            Application.Run(CredentialForm);
            this.GmailUsername = CredentialForm.GmailUsername;
            this.GmailPassword = CredentialForm.GmailPassword;
        }
    }
}
