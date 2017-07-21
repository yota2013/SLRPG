using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

public class JsonToString {

	/// <summary>
	/// Load JSON .txt file and convert it to string
	/// </summary>
	/// <returns>JSON string</returns>
	/// <param name="dir">Directory name contains .txt</param>
	/// <param name="fname">Filename (with ".txt")</param>
	public static string loadFromFile(string dir, string fname){

//		Dictionary<string, object> dic;

		const string dlm ="/";
		const string ext = ".txt";
		string relpath;
		string fullpath;
//		TextAsset json;
		string json;

		if(dir != "") {
			relpath = dlm + dir + dlm;
		}
		else {
			relpath = dlm;
		}

		if(Application.isEditor){// if editor, Application.dataPath=='Asset' folder
			fullpath = Application.dataPath + relpath + fname;
		}
		else{ // if PC/Mac, Application.dataPath=='***_data' folder
			fullpath = Application.dataPath + dlm + ".." + relpath + fname;
		}

		try{
			json = System.IO.File.ReadAllText(fullpath + ext);
//			json = Resources.Load (dir+dlm) as TextAsset;
		}
		catch (Exception ex){
			throw;
		}

		/*
		try{
			dic = Json.Deserialize(json) as Dictionary<string, object>; // only <string, object>
		}
		catch(Exception ex){
			throw;
		}

		return dic;
		*/
		return json;
	}
}
