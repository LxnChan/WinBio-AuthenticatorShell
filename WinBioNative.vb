Imports System
Imports System.Runtime.InteropServices

Module WinBioNative
	Private Const WINBIO_TYPE_FINGERPRINT As UInteger = &H8UI
	Private Const WINBIO_POOL_SYSTEM As UInteger = 1UI
	Private Const WINBIO_FLAG_DEFAULT As UInteger = 0UI

	<DllImport("winbio.dll", SetLastError:=False)> _
	Private Function WinBioOpenSession( _
		ByVal Factor As UInteger, _
		ByVal PoolType As UInteger, _
		ByVal Flags As UInteger, _
		ByVal UnitArray As IntPtr, _
		ByVal UnitCount As UIntPtr, _
		ByVal DatabaseId As IntPtr, _
		ByRef SessionHandle As ULong _
	) As Integer
	End Function

	<DllImport("winbio.dll", SetLastError:=False)> _
	Private Function WinBioIdentify( _
		ByVal SessionHandle As ULong, _
		ByRef UnitId As UInteger, _
		ByVal Identity As IntPtr, _
		ByRef SubFactor As Byte, _
		ByRef RejectDetail As UInteger _
	) As Integer
	End Function

	<DllImport("winbio.dll", SetLastError:=False)> _
	Private Function WinBioCloseSession( _
		ByVal SessionHandle As ULong _
	) As Integer
	End Function

	Public Function IdentifyCurrentFingerprint(ByRef subFactor As Byte, ByRef unitId As UInteger, ByRef hresult As Integer) As Boolean
		Dim session As ULong = 0UL
		Dim identityPtr As IntPtr = IntPtr.Zero
		Dim rejectDetail As UInteger = 0UI

		' Open a system pool session for fingerprint
		hresult = WinBioOpenSession(WINBIO_TYPE_FINGERPRINT, WINBIO_POOL_SYSTEM, WINBIO_FLAG_DEFAULT, IntPtr.Zero, UIntPtr.Zero, IntPtr.Zero, session)
		If hresult <> 0 Then
			Return False
		End If

		Try
			' Allocate a buffer for WINBIO_IDENTITY we won't read back here
			identityPtr = Marshal.AllocHGlobal(1024)
			Marshal.Copy(New Byte(1023) {}, 0, identityPtr, 1024)

			unitId = 0UI
			subFactor = 0
			rejectDetail = 0UI
			hresult = WinBioIdentify(session, unitId, identityPtr, subFactor, rejectDetail)
			Return hresult = 0
		Finally
			If identityPtr <> IntPtr.Zero Then
				Marshal.FreeHGlobal(identityPtr)
			End If
			If session <> 0UL Then
				WinBioCloseSession(session)
			End If
		End Try
	End Function

	Public Function FingerSubFactorToName(ByVal subFactor As Byte) As String
		'Select Case subFactor
		'	Case &HF1
		'		Return "Right Thumb"
		'	Case &HF2
		'		Return "Right Index"
		'	Case &HF3
		'		Return "Right Middle"
		'	Case &HF4
		'		Return "Right Ring"
		'	Case &HF5
		'		Return "Right Little"
		'	Case &H11
		'		Return "Left Thumb"
		'	Case &H12
		'		Return "Left Index"
		'	Case &H13
		'		Return "Left Middle"
		'	Case &H14
		'		Return "Left Ring"
		'	Case &H15
		'		Return "Left Little"
		'	Case Else
		'		Return "Unknown(" & subFactor.ToString() & ")"
		'End Select
		Return "Unknown(" & subFactor.ToString() & ")"
	End Function
End Module


