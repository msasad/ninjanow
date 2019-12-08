using SmsAnalyzeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsAnalyzeService.Areas.HelpPage.service
{
    public class SmsScoreComputer : IScoreComputer<SmsScoreComputerInpute, SmsCreditScore>
    {

        public SmsCreditScore Calculate(SmsScoreComputerInpute input)
        {
            double totalDebit = 0;
            double totalCredit = 0;
            List<TextMessage> messages = input.Message;
            {
                String bankname = null;
                String card = null;
                String vendor = null;
                String amount = null;
                String balance = null;
                String type = null;
                String month = null;
                String year = null;
                DateTime date = DateTime.Now;
                int p_d = 1;
                Dictionary<string, Dictionary<string, String>> processedMessages = new Dictionary<string, Dictionary<string, string>>();

                foreach (var message in messages)
                {

                    //String msg = "Thank you for using your SBI card 7798720001 for a transaction of Rs 99 at flipkart account balance: 2000";
                    string[] tokens = message.MessageBody.Split(' ');

                    DateTime d = message.SentTime;
                    month = d.ToString("MM");
                    year = d.ToString("yyyy");
                    bankname = null;
                    card = null;
                    vendor = null;
                    amount = null;
                    balance = null;
                    p_d = -1;
                    type = "null";
                    date = message.SentTime;
                    List<string> keys = new List<string>() { "Rs", "at", "balance:", "account" };
                    List<string> banknames = new List<string>() { "BOM", "SBI", "ICICI", "HDFC" };
                    List<string> types = new List<string>() { "credited", "debited", "EMI", "Bill" };
                    List<string> EMI_checks = new List<string>() { "received", "due" };
                    foreach (string t in types)
                    {
                        foreach (string token in tokens)
                        {
                            if (String.Compare(token, t, true) == 0)
                            {
                                type = t;
                                break;

                            }
                        }
                    }

                    if (type == "EMI")
                    {
                        foreach (String token in tokens)
                        {
                            if (token == "received")
                            {
                                p_d = 1;
                                break;
                            }
                            if (token == "due")
                            {
                                p_d = 0;
                                break;
                            }
                        }
                    }

                    foreach (string bank in banknames)
                    {
                        foreach (String token in tokens)
                        {
                            if (token == (bank))
                            {
                                bankname = bank;
                                break;
                            }
                        }
                    }
                    foreach (var tok in tokens)
                    {
                        if (tok.Contains(keys[0]))
                        {

                            amount = tok.Substring(3, tok.Length - 3);
                        }
                        if (tok == (keys[1]))
                        {
                            vendor = tok;
                        }
                        if (tok == (keys[2]))
                        {
                            balance = tok;
                        }
                        if (tok == (keys[3]))
                        {
                            card = tok;
                        }
                    }

                    if (type == "null")
                    {
                        type = "None";
                    }
                    else if (type == ("credited"))
                        type = "credit";
                    else if (type == ("debited"))
                        type = "debit";


                    /*System.out.println(("bankname" + bankname));
                    System.out.println("card" + card);
                    System.out.println("vendor" + vendor);
                    System.out.println("amount" + amount); 
                    System.out.println("balance" + balance);*/

                    if (type == "credit" || type == "debit")
                    {

                        Dictionary<string, string> value = new Dictionary<string, string>();
                        value.Add(" message ", message.MessageBody);
                        value.Add(" description --", "Credit / Debit ---- \n ");
                        value.Add("BANK ", bankname);
                        value.Add("CARD ", card);
                        value.Add("VENDOR ", vendor);
                        value.Add("AMOUNT ", amount);
                        value.Add("BALANCE ", balance);
                        value.Add("MONTH ", month);
                        value.Add("YEAR ", year);
                        value.Add("TYPE ", type);
                        processedMessages.Add(message.messageId, value);
                        Console.Out.Write(" \nM ==" + message.MessageBody);
                        Console.Out.Write(" \n --- Credit / Debit ---- \n ");
                        Console.Out.Write("BANK " + bankname);
                        Console.Out.Write("CARD " + card);
                        Console.Out.Write("VENDOR " + vendor);
                        Console.Out.Write("AMOUNT " + amount);
                        Console.Out.Write("BALANCE " + balance);
                        Console.Out.Write("MONTH " + month);
                        Console.Out.Write("YEAR " + year);
                        Console.Out.Write("TYPE " + type);
                        if (amount != null)
                        {
                            if (type == "debit")
                            {
                                totalDebit = totalDebit + Double.Parse(amount);
                            }
                            else
                            {
                                totalCredit = totalCredit + Double.Parse(amount);
                            }
                        }


                    }

                    if (type == ("EMI"))
                    {

                        Console.Out.Write(" \nM ==" + message.MessageBody);
                        Console.Out.Write(" \n --- EMI --- \n");
                        Console.Out.Write("ACCOUNT_NO " + card);
                        Console.Out.Write("EMI_AMOUNT " + amount);
                        Console.Out.Write("TYPE " + type);
                        Console.Out.Write("P_D " + p_d);

                        Dictionary<string, string> value = new Dictionary<string, string>();
                        value.Add(" \nM ==", message.MessageBody);
                        value.Add(" \n desc", " EMI --- \n");
                        value.Add("ACCOUNT_NO ", card);
                        value.Add("EMI_AMOUNT ", amount);
                        value.Add("TYPE ", type);
                        value.Add("P_D ", p_d.ToString());

                        //received EMI AMOUNT 
                        if (p_d == 1 && amount != null)
                        {
                            totalDebit = totalDebit + Double.Parse(amount);
                        }
                        processedMessages.Add(message.messageId, value);
                    }
                    if (type == "Bill")
                    {
                        Console.Out.Write(" \nM ==" + message.MessageBody);
                        Console.Out.Write(" \n --- Bill --- \n");
                        Console.Out.Write("TYPE " + type);
                        Console.Out.Write("AMOUNT " + amount);
                        Dictionary<string, string> value = new Dictionary<string, string>();
                        value.Add(" \nM ==", message.MessageBody);
                        value.Add(" desc", "--- Bill --- \n");
                        value.Add("TYPE ", type);
                        value.Add("AMOUNT ", amount);
                        processedMessages.Add(message.messageId, value);
                        if (amount != null)
                        {
                            totalDebit = totalDebit + Double.Parse(amount);
                        }
                    }


                }
            }

            var smsCreditScore = new SmsCreditScore();
            smsCreditScore.updateScore(totalCredit - totalDebit) ;
            return smsCreditScore;
        }
    }
}
