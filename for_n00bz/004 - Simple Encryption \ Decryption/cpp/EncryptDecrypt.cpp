#include "ShiftEncryptor.h"
void main()
{
	int choice = 0;
	int shift = 0;
	string test, result, key;
	CaesarEncryptor c;
	VigenereEncryptor v;
	while (true)
	{
		system("cls");
		cout << "Enter string: ";
		cin >> test;
		cout << "Choose option: " << endl;
		cout << "1) Caesar cipher" << endl;
		cout << "2) Vigenere cipher" << endl;
		cout << "0) Exit " << endl;
		cin >> choice;

		switch (choice)
		{
			case 1:
				cout << "Enter shift: ";
				cin >> shift;
				result = c.encrypt(test, shift);
				cout << "Encrypted: " << result << endl;
				cout << "Back decryption: " << c.decrypt(result, shift) << endl << endl;
				system("pause");
				break;
			case 2:
				cout << "Enter key: ";
				cin >> key;
				result = v.encrypt(test, key);
				cout << "Encrypted: " << result << endl;
				cout << "Back decryption: " << v.decrypt(result, key) << endl << endl;
				system("pause");
				break;
			case 0: 
				exit(1);
				break;
			default:
				break;
		}
	}
}