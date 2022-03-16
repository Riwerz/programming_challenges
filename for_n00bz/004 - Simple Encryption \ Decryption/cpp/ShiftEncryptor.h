#pragma once

#include <iostream>
#include <string>
#include <cmath>
using namespace std;


template<typename T>
class BaseShiftEncryptor
{
protected:
	const string alphabet = "abcdefghijklmnopqrstuvwxyz";
public:

	BaseShiftEncryptor() {}
	virtual string encrypt(const string& value, const T& param) = 0;
	virtual string decrypt(const string& value, const T& param) = 0;
	virtual ~BaseShiftEncryptor() {};
};


class CaesarEncryptor : public BaseShiftEncryptor<int>
{
public:
	CaesarEncryptor() {};

	string encrypt(const string& plaintext, const int& shift)
	{
		string answer;
		for (int i = 0; i < plaintext.length(); i++)
		{
			int letterPos = (alphabet.find(plaintext[i]) + shift) % alphabet.length();

			answer += alphabet[letterPos];

		}
		return answer;
	}

	string decrypt(const string& plaintext, const int& shift)
	{

		string answer;
		for (int i = 0; i < plaintext.length(); i++)
		{
			int letterPos = (alphabet.find(plaintext[i]) - shift);
			if (letterPos < 0)
			{
				letterPos = alphabet.length() + letterPos;
			}
			answer += alphabet[letterPos];

		}
		return answer;
	}

	~CaesarEncryptor() {};
};


class VigenereEncryptor : public BaseShiftEncryptor<string>
{
public:
	VigenereEncryptor() {};

	string encrypt(const string& plaintext, const string& key)
	{
		string answer;
		for (int i = 0; i < plaintext.length(); i++)
		{
			int keyPos = alphabet.find(key[i % key.length()]);
			int letterPos = (alphabet.find(plaintext[i]) + keyPos) % alphabet.length();

			answer += alphabet[letterPos];

		}
		return answer;
	}

	string decrypt(const string& plaintext, const string& key)
	{
		string answer;
		for (int i = 0; i < plaintext.length(); i++)
		{
			int keyPos = alphabet.find(key[i % key.length()]);
			int letterPos = (alphabet.find(plaintext[i]) - keyPos);
			if (letterPos < 0)
			{
				letterPos = alphabet.length() + letterPos;
			}

			answer += alphabet[letterPos];

		}
		return answer;
	}

	~VigenereEncryptor() {};
};