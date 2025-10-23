# WinBio App Authenticator

<img width="537" height="342" alt="Image" src="https://github.com/user-attachments/assets/3b4a49d8-671d-45bd-ac50-6c3ce8b2f74e" />

This is an application authentication shell based on WinBio (the Windows Biometric Framework), developed in Visual Basic .NET.
Its primary use case is demonstrating applications that require dual-user verification before they can be launched.

## Config.json

```json
{"fpA":"246","fpB":"247","sppath":"C:\\Program Files\\Bandizip\\Bandizip.exe"}
```

- `fpA`: Fingerprint A ID
- `fpB`: Fingerprint B ID
- `sppath`: App's Path

## How to get Fingerprint ID

First, you need add your fingerprint in Windows Hello.

Compile and start this shell, click "CurrentID", and put your finger above scanner, and then the ID will appear.

<img width="537" height="342" alt="Image" src="https://github.com/user-attachments/assets/40d2c396-b358-4907-b1dc-7f10d6f5c123" />
