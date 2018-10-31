﻿using UnityEngine;
using System.Collections;
using Nethereum.JsonRpc.UnityClient;
using Nethereum.Hex.HexTypes;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using Nethereum.ABI;
using Nethereum.Signer;
using Nethereum.Hex.HexConvertors.Extensions;
using System;
using Newtonsoft.Json;

public class Account : MonoBehaviour
{

    // Here we define accountAddress (the public key; We are going to extract it later using the private key)
    private string accountAddress;
    // This is the secret key of the address, you should put yours.
    private string accountPrivateKey = "C2F69A24F5D49D8171E0CD419F7CB5462207DE428A2EFD74A8773B1A76FE32B9";
    // This is the testnet we are going to use for our contract, in this case kovan
    private string _url = "http://ethereum.it.jyu.fi:8545";
    // contract address
    private static string contractAddress = "http://ethereum.it.jyu.fi/pelikurssi/contracts";
    // We define a new contract (Netherum.Contracts)
    private Contract contract;

    // Use this for initialization
    void Start()
    {
        // First we'll call this function which will extract and assign the public key from the accountPrivateKey defined above.
        importAccountFromPrivateKey();  
        Debug.Log("Account import OK");

        // check balance of imported account
        StartCoroutine(getAccountBalance(accountAddress, (balance) => {
            Debug.Log("Account balance: " + balance);
        }));

        // get wallet
        Debug.Log("Getting wallet...");
        StartCoroutine(getWallet());

        // get assets from wallet
        //Debug.Log("Getting assets...");
        //StartCoroutine(getAssets((haettu) =>{
        //    Debug.Log("Assetit : " + haettu);
        //}));
    }

    private bool walletFound = false;
    private IEnumerator getWallet()
    {
        // read json and get abi and bytecode
        string jsonString = System.IO.File.ReadAllText("Assets/JSON/WalletDB.json");
        var parsed = Newtonsoft.Json.Linq.JObject.Parse(jsonString);
        string ABIstring = parsed.GetValue("abi").ToString();
        string BCstring = parsed.GetValue("bytecode").ToString();

        // new request
        var req = new EthCallUnityRequest(_url);
        // new contract from contract address
        var contract = new Contract(null, ABIstring, accountAddress);         
        Function func = contract.GetFunction("getWallet");

        // parameters for sendrequest
        var callinput = func.CreateCallInput(accountAddress);
        var blockparam = BlockParameter.CreateLatest();

        // returns 0x -> not enough gas?

        yield return req.SendRequest(callinput, blockparam);
        if (req.Exception == null)
        {
            Debug.Log("Wallet found: " + req.Result);
            walletFound = true;
        }
        else
        {
            throw new InvalidOperationException("Get wallet request failed");
        }
    }

    public IEnumerator getAssets(Action<string> haettu)
    {
        yield return new WaitForSeconds(5);
        // read json and get abi and bytecode
        string jsonString2 = System.IO.File.ReadAllText("Assets/JSON/GameWallet.json");
        var parsed2 = Newtonsoft.Json.Linq.JObject.Parse(jsonString2);
        string ABIstring2 = parsed2.GetValue("abi").ToString();
        string BCstring2 = parsed2.GetValue("bytecode").ToString();

        // new request
        var req = new EthCallUnityRequest(_url);
        // new contract and wanted function from contract address
        var contract = new Contract(null, ABIstring2, accountAddress);
        var func = contract.GetFunction("getAssets");

        // parameters for sendrequest
        var callinput = func.CreateCallInput();
        var blockparam = BlockParameter.CreateLatest();

        yield return req.SendRequest(callinput, blockparam);
        if (req.Exception == null)
        {
            var result = req.Result;
            haettu(result);
        }
        else
        {
            throw new InvalidOperationException("Get assets request failed");
        }
    }
    
    public IEnumerator getAccountBalance(string address, System.Action<decimal> callback)
    {
        var getBalanceRequest = new EthGetBalanceUnityRequest(_url);
        yield return getBalanceRequest.SendRequest(address, BlockParameter.CreateLatest());
        if (getBalanceRequest.Exception == null)
        {
            var balance = getBalanceRequest.Result.Value;
            callback(Nethereum.Util.UnitConversion.Convert.FromWei(balance, 18));
        }
        else
        {
            throw new InvalidOperationException("Get balance request failed");
        }

    }

    public void importAccountFromPrivateKey()
    {
        // Here we try to get the public address from the secretKey we defined
        try
        {
            var address = EthECKey.GetPublicAddress(accountPrivateKey);
            // Then we define the accountAdress private variable with the public key
            accountAddress = address;
        }
        catch (Exception e)
        {
            // If we catch some error when getting the public address, we just display the exception in the console
            Debug.Log("Error importing account from PrivateKey: " + e);
        }
    }
}