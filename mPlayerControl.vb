Public Class mPlayerControl
  Inherits Control

  ' Public Enum

  Public Enum Channels
    None = 0
    Left = 1
    Right = 2
    Both = 3
  End Enum

  ' API Constants, Enum and Functions

  Private Const MCI_NOTIFY_SUCCESSFUL As Integer = &H1
  Private Const MM_MCINOTIFY As Integer = &H3B9
  Private Const MCIERR_BASE As Integer = 256

  ' MCI Error Values Enumeration
  Private Enum MCIERR As Integer
    MCIERR_NO_ERROR = 0
    MCIERR_INVALID_DEVICE_ID = (MCIERR_BASE + 1)
    MCIERR_UNRECOGNIZED_KEYWORD = (MCIERR_BASE + 3)
    MCIERR_UNRECOGNIZED_COMMAND = (MCIERR_BASE + 5)
    MCIERR_HARDWARE = (MCIERR_BASE + 6)
    MCIERR_INVALID_DEVICE_NAME = (MCIERR_BASE + 7)
    MCIERR_OUT_OF_MEMORY = (MCIERR_BASE + 8)
    MCIERR_DEVICE_OPEN = (MCIERR_BASE + 9)
    MCIERR_CANNOT_LOAD_DRIVER = (MCIERR_BASE + 10)
    MCIERR_MISSING_COMMAND_STRING = (MCIERR_BASE + 11)
    MCIERR_PARAM_OVERFLOW = (MCIERR_BASE + 12)
    MCIERR_MISSING_STRING_ARGUMENT = (MCIERR_BASE + 13)
    MCIERR_BAD_INTEGER = (MCIERR_BASE + 14)
    MCIERR_PARSER_INTERNAL = (MCIERR_BASE + 15)
    MCIERR_DRIVER_INTERNAL = (MCIERR_BASE + 16)
    MCIERR_MISSING_PARAMETER = (MCIERR_BASE + 17)
    MCIERR_UNSUPPORTED_FUNCTION = (MCIERR_BASE + 18)
    MCIERR_FILE_NOT_FOUND = (MCIERR_BASE + 19)
    MCIERR_DEVICE_NOT_READY = (MCIERR_BASE + 20)
    MCIERR_INTERNAL = (MCIERR_BASE + 21)
    MCIERR_DRIVER = (MCIERR_BASE + 22)
    MCIERR_CANNOT_USE_ALL = (MCIERR_BASE + 23)
    MCIERR_MULTIPLE = (MCIERR_BASE + 24)
    MCIERR_EXTENSION_NOT_FOUND = (MCIERR_BASE + 25)
    MCIERR_OUTOFRANGE = (MCIERR_BASE + 26)
    MCIERR_FLAGS_NOT_COMPATIBLE = (MCIERR_BASE + 28)
    MCIERR_FILE_NOT_SAVED = (MCIERR_BASE + 30)
    MCIERR_DEVICE_TYPE_REQUIRED = (MCIERR_BASE + 31)
    MCIERR_DEVICE_LOCKED = (MCIERR_BASE + 32)
    MCIERR_DUPLICATE_ALIAS = (MCIERR_BASE + 33)
    MCIERR_BAD_CONSTANT = (MCIERR_BASE + 34)
    MCIERR_MUST_USE_SHAREABLE = (MCIERR_BASE + 35)
    MCIERR_MISSING_DEVICE_NAME = (MCIERR_BASE + 36)
    MCIERR_BAD_TIME_FORMAT = (MCIERR_BASE + 37)
    MCIERR_NO_CLOSING_QUOTE = (MCIERR_BASE + 38)
    MCIERR_DUPLICATE_FLAGS = (MCIERR_BASE + 39)
    MCIERR_INVALID_FILE = (MCIERR_BASE + 40)
    MCIERR_NULL_PARAMETER_BLOCK = (MCIERR_BASE + 41)
    MCIERR_UNNAMED_RESOURCE = (MCIERR_BASE + 42)
    MCIERR_NEW_REQUIRES_ALIAS = (MCIERR_BASE + 43)
    MCIERR_NOTIFY_ON_AUTO_OPEN = (MCIERR_BASE + 44)
    MCIERR_NO_ELEMENT_ALLOWED = (MCIERR_BASE + 45)
    MCIERR_NONAPPLICABLE_FUNCTION = (MCIERR_BASE + 46)
    MCIERR_ILLEGAL_FOR_AUTO_OPEN = (MCIERR_BASE + 47)
    MCIERR_FILENAME_REQUIRED = (MCIERR_BASE + 48)
    MCIERR_EXTRA_CHARACTERS = (MCIERR_BASE + 49)
    MCIERR_DEVICE_NOT_INSTALLED = (MCIERR_BASE + 50)
    MCIERR_GET_CD = (MCIERR_BASE + 51)
    MCIERR_SET_CD = (MCIERR_BASE + 52)
    MCIERR_SET_DRIVE = (MCIERR_BASE + 53)
    MCIERR_DEVICE_LENGTH = (MCIERR_BASE + 54)
    MCIERR_DEVICE_ORD_LENGTH = (MCIERR_BASE + 55)
    MCIERR_NO_INTEGER = (MCIERR_BASE + 56)

    MCIERR_WAVE_OUTPUTSINUSE = (MCIERR_BASE + 64)
    MCIERR_WAVE_SETOUTPUTINUSE = (MCIERR_BASE + 65)
    MCIERR_WAVE_INPUTSINUSE = (MCIERR_BASE + 66)
    MCIERR_WAVE_SETINPUTINUSE = (MCIERR_BASE + 67)
    MCIERR_WAVE_OUTPUTUNSPECIFIED = (MCIERR_BASE + 68)
    MCIERR_WAVE_INPUTUNSPECIFIED = (MCIERR_BASE + 69)
    MCIERR_WAVE_OUTPUTSUNSUITABLE = (MCIERR_BASE + 70)
    MCIERR_WAVE_SETOUTPUTUNSUITABLE = (MCIERR_BASE + 71)
    MCIERR_WAVE_INPUTSUNSUITABLE = (MCIERR_BASE + 72)
    MCIERR_WAVE_SETINPUTUNSUITABLE = (MCIERR_BASE + 73)

    MCIERR_SEQ_DIV_INCOMPATIBLE = (MCIERR_BASE + 80)
    MCIERR_SEQ_PORT_INUSE = (MCIERR_BASE + 81)
    MCIERR_SEQ_PORT_NONEXISTENT = (MCIERR_BASE + 82)
    MCIERR_SEQ_PORT_MAPNODEVICE = (MCIERR_BASE + 83)
    MCIERR_SEQ_PORT_MISCERROR = (MCIERR_BASE + 84)
    MCIERR_SEQ_TIMER = (MCIERR_BASE + 85)
    MCIERR_SEQ_PORTUNSPECIFIED = (MCIERR_BASE + 86)
    MCIERR_SEQ_NOMIDIPRESENT = (MCIERR_BASE + 87)

    MCIERR_NO_WINDOW = (MCIERR_BASE + 90)
    MCIERR_CREATEWINDOW = (MCIERR_BASE + 91)
    MCIERR_FILE_READ = (MCIERR_BASE + 92)
    MCIERR_FILE_WRITE = (MCIERR_BASE + 93)

    MCIERR_NO_IDENTITY = (MCIERR_BASE + 94)
    ' Custom Driver Errors are greater or equal to this value
    MCIERR_CUSTOM_DRIVER_BASE = (MCIERR_BASE + 256)
  End Enum

  Private Declare Function mciSendString Lib "Winmm.dll" _
  Alias "mciSendStringA" (ByVal lpszCommand As String, ByVal lpszReturnString As String, _
                          ByVal cchReturn As Integer, ByVal hwndCallback As IntPtr) As MCIERR
  Private Declare Function mciGetErrorString Lib "Winmm.dll" _
  Alias "mciGetErrorStringA" (ByVal fdwError As Integer, ByVal lpszErrorText As String, _
                              ByVal cchErrorText As Integer) As Integer

  ' Private Members

  Private pFileName As String  ' The media file opened
  Private pAlias As String ' Each control instance gets own unique alias
  Private pLastError As MCIERR ' Error returned mciSendString last call
  Private pOpenSuccess As Boolean ' Indicates Open command successful
  Private pSpeed As Integer ' Playback speed
  Private pMute As Channels ' Muted Channels  
  Private pBalance As Integer ' Left / Right balance
  Private pVolume As Integer ' Volume
  Private pRepeat As Boolean ' Indicates playback looping
  Private pTotalTime As Long ' Media length in milliseconds
  Private pTotalFrames As Long ' Media length in frames
  Private pClipStart As Long ' Start frame or milliseconds of play sequence
  Private pClipEnd As Long ' End frame or milliseconds of play sequence
  Private pClipFormat As String ' Time format for Clip frames or milliseconds
  Private pPlaying As Boolean ' Is Playing
  Private pPaused As Boolean ' IsPaused

  ' Private Methods

  ''' <summary>Set Playback Speed</summary>
  Private Function DoSpeed() As Boolean
    If pOpenSuccess Then
      pLastError = mciSendString("set " & pAlias & _
                                 " speed " & CStr(pSpeed), _
                                 vbNullString, 0, IntPtr.Zero)
      Return (pLastError = MCIERR.MCIERR_NO_ERROR)
    End If
    Return False
  End Function

  ''' <summary>Mute the Channels</summary>
  Private Function DoMute() As Boolean
    If pOpenSuccess Then
      Select Case pMute
        Case Channels.None
          pLastError = mciSendString("set " & pAlias & _
                                     " audio all on", _
                                     vbNullString, 0, IntPtr.Zero)
        Case Channels.Both
          pLastError = mciSendString("set " & pAlias & _
                                     " audio all off", _
                                     vbNullString, 0, IntPtr.Zero)
        Case Channels.Left
          pLastError = mciSendString("set " & pAlias & _
                                     " audio left off", _
                                     vbNullString, 0, IntPtr.Zero)
          pLastError = mciSendString("set " & pAlias & _
                                     " audio right on", _
                                     vbNullString, 0, IntPtr.Zero)
        Case Channels.Right
          pLastError = mciSendString("set " & pAlias & _
                                     " audio left on", _
                                     vbNullString, 0, IntPtr.Zero)
          pLastError = mciSendString("set " & pAlias & _
                                     " audio right off", _
                                     vbNullString, 0, IntPtr.Zero)
      End Select
      Return (pLastError = MCIERR.MCIERR_NO_ERROR)
    End If
    Return False
  End Function

  ''' <summary>Set Balance factor</summary>
  Private Function DoBalance() As Boolean
    If pOpenSuccess Then
      pLastError = mciSendString("setaudio " & pAlias & _
                                 " left volume to " & CStr(1000 - pBalance), _
                                 vbNullString, 0, IntPtr.Zero)
      pLastError = mciSendString("setaudio " & pAlias & _
                                 " right volume to " & CStr(pBalance), _
                                 vbNullString, 0, IntPtr.Zero)
      Return (pLastError = MCIERR.MCIERR_NO_ERROR)
    End If
    Return False
  End Function

  ''' <summary>Set Volume Factor</summary>
  Private Function DoVolume() As Boolean
    If pOpenSuccess Then
      pLastError = mciSendString("setaudio " & pAlias & _
                                 " volume to " & CStr(pVolume), _
                                 vbNullString, 0, IntPtr.Zero)
      Return (pLastError = MCIERR.MCIERR_NO_ERROR)
    End If
    Return False
  End Function

  ''' <summary>Return Total number of Frames in media</summary>
  Private Function GetTotalFrames() As Long
    If pOpenSuccess Then
      pLastError = mciSendString("set " & pAlias & _
                                 " time format frames", _
                                 vbNullString, 0, IntPtr.Zero)
      If pLastError = MCIERR.MCIERR_NO_ERROR Then
        Dim FrameStr As String = Space(128)
        pLastError = mciSendString("status " & pAlias & _
                                   " length", FrameStr, _
                                   Len(FrameStr), IntPtr.Zero)
        If pLastError = MCIERR.MCIERR_NO_ERROR Then
          Return CLng(Trim(FrameStr))
        End If
      End If
    End If
    Return -1
  End Function

  ''' <summary>Return Total playing time in milliseconds of Media</summary>
  Private Function GetTotalTime() As Long
    If pOpenSuccess Then
      pLastError = mciSendString("set " & pAlias & _
                                 " time format milliseconds", _
                                 vbNullString, 0, IntPtr.Zero)
      If pLastError = MCIERR.MCIERR_NO_ERROR Then
        Dim TimeStr As String = Space(128)
        pLastError = mciSendString("status " & pAlias & _
                                   " length", TimeStr, _
                                   Len(TimeStr), IntPtr.Zero)
        If pLastError = MCIERR.MCIERR_NO_ERROR Then
          Return CLng(Trim(TimeStr))
        End If
      End If
    End If
    Return -1
  End Function

  ''' <summary>Size media to fit window, preserve aspect ratio</summary>
  Private Function SizeMediaWindow() As Boolean
    If pOpenSuccess Then
      Dim OptimalSize As Size = Me.OriginalSize ' Get media optimal size
      If OptimalSize.IsEmpty = False Then ' Calculate ratio to size to the width
        Dim wRatio As Double = (100 / OptimalSize.Width * Me.Width) / 100
        ' Verify window is high enough for ratio.
        If OptimalSize.Height * wRatio > Me.Height Then
          ' If not calculate ratio if size to the height
          wRatio = (100 / OptimalSize.Height * Me.Height) / 100
        End If
        ' Calculate width and height for ratio
        ' Calculate Left and Top to centre media
        Dim wWidth As Integer = CInt(OptimalSize.Width * wRatio)
        Dim wHeight As Integer = CInt(OptimalSize.Height * wRatio)
        Dim wLeft As Integer = CInt((Me.Width - wWidth) / 2)
        Dim wTop As Integer = CInt((Me.Height - wHeight) / 2)
        ' Send Command
        pLastError = mciSendString("put " & pAlias & _
                                   " window at " & CStr(wLeft) & " " _
                                   & CStr(wTop) & " " & CStr(wWidth) & " " _
                                   & CStr(wHeight), vbNullString, 0, IntPtr.Zero)
        Return (pLastError = MCIERR.MCIERR_NO_ERROR)
      End If
    End If
    Return False
  End Function

  ''' <summary>Play Media, Specifiying which part of Media to play</summary>
  ''' <param name="WithClipStart">Indicates the Start Index of Clip that should be used</param>
  ''' <param name="WithClipEnd">Indicates the End Index of Clip that should be used</param>
  ''' <param name="WithPauseState">Indicates the current Pause state should be respected</param>
  Private Function [Play](ByVal WithClipStart As Boolean, _
                          ByVal WithClipEnd As Boolean, _
                          ByVal WithPauseState As Boolean) As Boolean
    If pOpenSuccess Then ' Start Media Playing
      If pClipFormat.Length > 0 Then ' If Clip, specify the timer format
        pLastError = mciSendString("set " & pAlias _
                                   & " time format " & pClipFormat, _
                                   vbNullString, 0, IntPtr.Zero)
      End If
      ' Send the play command, we want to be notified when playing ends
      pLastError = mciSendString("play " & pAlias & CStr(IIf((pClipStart <> -1) And WithClipStart = True, _
                                  " from " & CStr(pClipStart), "")) & CStr(IIf((pClipEnd <> -1) And _
                                  WithClipEnd = True, " to " & CStr(pClipEnd), "")) & " notify", _
                                  vbNullString, 0, Me.Handle)
      If pLastError = MCIERR.MCIERR_NO_ERROR Then
        pPlaying = True
        ' If need to respect Pause state and Paused
        If WithPauseState And pPaused Then
          Me.Pause()
        Else ' No paused or pause state can be ignored / reset
          pPaused = False
        End If
      End If
      Return (pLastError = MCIERR.MCIERR_NO_ERROR)
    End If
    Return False
  End Function

  ''' <summary>Clip Media</summary>
  ''' <param name="Start">Set Clip Start</param>
  ''' <param name="End">Set Clip End</param>
  ''' <param name="Current">Current Position</param>
  ''' <param name="TimeFormat">Time Format</param>
  Private Function Clip(ByVal [Start] As Long, ByVal [End] As Long, _
                        ByVal Current As Long, ByVal TimeFormat As String) As Boolean
    If pOpenSuccess Then
      If [Start] <> pClipStart Or [End] <> pClipEnd _
      Or TimeFormat <> pClipFormat Then
        pClipStart = [Start]
        pClipEnd = [End]
        If pClipStart = -1 And pClipEnd = -1 Then
          pClipFormat = "" ' Start / End set to -1 Disables
        Else
          pClipFormat = TimeFormat
        End If
        If pPlaying Then ' If Playing apply Clip now
          ' Skip to start if positioned before, otherwise handled by MCI
          Me.Play(([Start] > Current And [Start] <> -1), True, True)
        End If
        Return True
      End If
    End If
    Return False
  End Function

  ''' <summary>Move the Media to its desired Index using Specified Time Format</summary>
  ''' <param name="Index">Media Position Index</param>
  ''' <param name="TimeFormat">Desired Time Format</param>
  Private Function MoveToPosition(ByVal Index As Long, _
                                  ByVal TimeFormat As String) As Boolean
    If pOpenSuccess Then
      pLastError = mciSendString("set " & pAlias & _
                                 " time format " & TimeFormat, _
                                 vbNullString, 0, IntPtr.Zero)
      If pLastError = MCIERR.MCIERR_NO_ERROR Then
        pLastError = mciSendString("seek " & pAlias & _
                                   " to " & CStr(Index), _
                                   vbNullString, 0, IntPtr.Zero)
        If pLastError = MCIERR.MCIERR_NO_ERROR Then
          If pPlaying Then
            Me.Play(False, True, True) ' Resume Playback
          End If
        End If
        Return (pLastError = MCIERR.MCIERR_NO_ERROR)
      End If
    End If
    Return False
  End Function

  ' Constructor

  Public Sub New()
    pFileName = "" ' No media loaded
    pAlias = "ALIAS" & Me.Handle.ToString ' Each Control has Unique Alias
    pLastError = MCIERR.MCIERR_NO_ERROR ' No error
    pOpenSuccess = False ' Not open
    pSpeed = 1000 ' Normal playback speed
    pMute = Channels.None ' No muted channels muted
    pBalance = 500 ' Normal left / right balance
    pVolume = 500 ' Normal volume
    pRepeat = False ' Default no playback looping
    pTotalTime = -1 ' No media
    pTotalFrames = -1 ' No media
    pClipStart = -1 ' Start at beginning
    pClipEnd = -1 ' Play until end 
    pClipFormat = "" ' No clip format
    pPlaying = False ' Not playing
    pPaused = False ' Not Paused
  End Sub

  ' Public Methods

  ''' <summary>Return last MCI Error Code</summary>
  Public Function GetLastError() As Integer
    Return pLastError
  End Function

  ''' <summary>Return Description for last MCI error</summary>
  Public Function GetErrorString() As String
    If pLastError <> MCIERR.MCIERR_NO_ERROR Then
      Dim ErrorText As String = Space(128)
      If mciGetErrorString(pLastError, ErrorText, _
                           Len(ErrorText)) <> 0 Then
        Return Trim(ErrorText)
      End If
    End If
    Return ""
  End Function

  ''' <summary>Close Media File</summary>  
  Public Function [Close]() As Boolean
    If pOpenSuccess Then
      pLastError = mciSendString("close " & pAlias, _
                                 vbNullString, 0, IntPtr.Zero)
      If pLastError = MCIERR.MCIERR_NO_ERROR Then
        pOpenSuccess = False
        pPlaying = False
        pPaused = False
        pFileName = "" ' No File Open
        pTotalTime = -1 ' No Media
        pTotalFrames = -1 ' No Media
        Return True
      End If
    End If
    Return False
  End Function

  ''' <summary>Stop Media</summary> 
  Public Function [Stop]() As Boolean
    If pOpenSuccess Then
      pLastError = mciSendString("stop " & pAlias, _
                                 vbNullString, 0, IntPtr.Zero)
      If pLastError = MCIERR.MCIERR_NO_ERROR Then
        ' After stopping be kind, rewind
        pLastError = mciSendString("seek " & pAlias & _
                                   " to start", vbNullString, _
                                   0, IntPtr.Zero)
      End If
      pPlaying = False
      pPaused = False
      Return (pLastError = MCIERR.MCIERR_NO_ERROR)
    End If
    Return False
  End Function

  ''' <summary>Pause Media</summary>
  Public Function [Pause]() As Boolean
    If pOpenSuccess Then
      pLastError = mciSendString("pause " & pAlias, _
                                 vbNullString, 0, IntPtr.Zero)
      pPaused = (pLastError = MCIERR.MCIERR_NO_ERROR)
      Return pPaused
    End If
    Return False
  End Function

  ''' <summary>Resume Media</summary>
  Public Function [Resume]() As Boolean
    If pOpenSuccess And pPaused Then
      pLastError = mciSendString("resume " & pAlias, _
                                 vbNullString, 0, IntPtr.Zero)
      pPaused = Not (pLastError = MCIERR.MCIERR_NO_ERROR)
      Return (pLastError = MCIERR.MCIERR_NO_ERROR)
    End If
    Return False
  End Function

  ''' <summary>Move to Media End</summary>
  Public Function MoveToEnd() As Boolean
    If pOpenSuccess Then
      pLastError = mciSendString("seek " & pAlias & _
                                 " to end", vbNullString, 0, IntPtr.Zero)
      pPlaying = False ' Seeks stops Playback
      pPaused = False
      Return (pLastError = MCIERR.MCIERR_NO_ERROR)
    End If
    Return False
  End Function

  ''' <summary>Open Media File (MIDI and CD Audio not supported)</summary>  
  ''' <param name="File">The filename of the Media</param>  
  Public Function [Open](ByVal File As String) As Boolean
    If pOpenSuccess Then
      Me.Close() ' Close the previous file
    End If
    Dim Device_Type As String = "MPEGVideo" ' Get Device type, MPEGVideo or AVIVideo
    Dim MciExtension As Microsoft.Win32.RegistryKey = _
    Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\MCI Extensions", False)
    If Not MciExtension Is Nothing Then
      Device_Type = CStr(MciExtension.GetValue(Replace(System.IO.Path.GetExtension(File), ".", ""), "MPEGVideo"))
    End If
    ' Try to Open File, Check for Errors
    pLastError = mciSendString("open """ & File & """ type " & Device_Type & _
                               " alias " & pAlias & "  parent " & Me.Handle.ToString & _
                               " style child", vbNullString, 0, IntPtr.Zero)
    If pLastError = MCIERR.MCIERR_NO_ERROR Then
      ' Set Media Flags
      pOpenSuccess = True
      pPlaying = False
      pPaused = False
      ' Remember Filename
      pFileName = File
      ' Initialise Media
      SizeMediaWindow()
      DoSpeed()
      DoMute()
      DoBalance()
      DoVolume()
      ' Get Media Stats
      pTotalTime = GetTotalTime()
      pTotalFrames = GetTotalFrames()
      Return True
    End If
    Return False
  End Function

  ''' <summary>Play Media</summary>  
  Public Function [Play]() As Boolean
    Return Me.Play(True, True, False)
  End Function

  ''' <summary>Move to Media to Desired Frame</summary>
  ''' <param name="Frame">Frame Number</param>
  Public Function MoveToFrame(ByVal Frame As Long) As Boolean
    Return MoveToPosition(Frame, "frames")
  End Function

  ''' <summary>Move to Media to Desired Time Index</summary>
  ''' <param name="Milliseconds">Time Index</param>
  Public Function MoveToTime(ByVal Milliseconds As Long) As Boolean
    Return MoveToPosition(Milliseconds, "milliseconds")
  End Function

  ''' <summary>Clip media to only play between Start and End frame</summary>
  ''' <param name="Start">Start Frame</param>
  ''' <param name="End">End Frame</param>
  Public Function ClipFrame(ByVal [Start] As Long, ByVal [End] As Long) As Boolean
    Return Clip([Start], [End], Me.CurrentFrame, "frames") ' Undo with -1 
  End Function

  ''' <summary>Clip media to only play between Start and End Time</summary>
  ''' <param name="Start">Start Time Index</param>
  ''' <param name="End">End Time Index</param>
  Public Function ClipTime(ByVal [Start] As Long, ByVal [End] As Long) As Boolean
    Return Clip([Start], [End], Me.CurrentTime, "milliseconds") ' Undo with -1
  End Function

  ' Public Properties

  ''' <summary>Filename of Opened File</summary>
  Public ReadOnly Property FileName() As String
    Get
      Return pFileName
    End Get
  End Property

  ''' <summary>Repeat Media, If Set Loop Media</summary>
  Public Property Repeat() As Boolean
    Get
      Return pRepeat
    End Get
    Set(ByVal Value As Boolean)
      If pRepeat <> Value Then
        pRepeat = Value
      End If
    End Set
  End Property

  ''' <summary>Obtain the screen size of Media</summary>
  Public ReadOnly Property OriginalSize() As Size
    Get
      If pOpenSuccess Then
        Dim SizeStr As String = Space(128)
        pLastError = mciSendString("where " & pAlias & _
                     " source", SizeStr, _
                     Len(SizeStr), IntPtr.Zero)
        If pLastError = MCIERR.MCIERR_NO_ERROR Then
          Dim Items() As String = Split(Trim(SizeStr), " ")
          Return New Size(CInt(Items(2)), CInt(Items(3)))
        End If
      End If
      Return New Size
    End Get
  End Property

  ''' <summary>Number of frames in media or -1 is no media opened or unsupported</summary>
  Public ReadOnly Property TotalFrames() As Long
    Get
      Return pTotalFrames
    End Get
  End Property

  ''' <summary>Total time of media in milliseconds</summary>
  Public ReadOnly Property TotalTime() As Long
    Get
      Return pTotalTime
    End Get
  End Property

  ''' <summary>Current Frame index in Media</summary>
  Public ReadOnly Property CurrentFrame() As Long
    Get
      If pOpenSuccess Then
        pLastError = mciSendString("set " & pAlias & _
                                   " time format frames", _
                                   vbNullString, 0, IntPtr.Zero)
        If pLastError = MCIERR.MCIERR_NO_ERROR Then
          Dim PosStr As String = Space(128)
          pLastError = mciSendString("status " & pAlias & _
                                     " position", PosStr, _
                                     Len(PosStr), IntPtr.Zero)
          Return CLng(Trim(PosStr))
        End If
      End If
      Return -1
    End Get
  End Property

  ''' <summary>Current Time index in Media in milliseconds</summary>
  Public ReadOnly Property CurrentTime() As Long
    Get
      If pOpenSuccess Then
        pLastError = mciSendString("set " & pAlias & _
                                   " time format milliseconds", _
                                   vbNullString, 0, IntPtr.Zero)
        If pLastError = MCIERR.MCIERR_NO_ERROR Then
          Dim PosStr As String = Space(128)
          pLastError = mciSendString("status " & pAlias & _
                                     " position", PosStr, _
                                     Len(PosStr), IntPtr.Zero)
          Return CLng(Trim(PosStr))
        End If
      End If
      Return -1
    End Get
  End Property

  ''' <summary>Is Media Playing?</summary>
  Public ReadOnly Property Playing() As Boolean
    Get
      Return pPlaying
    End Get
  End Property

  ''' <summary>Is Media Paused?</summary>
  Public ReadOnly Property Paused() As Boolean
    Get
      Return pPaused
    End Get
  End Property

  ''' <summary>Playback speed (1-2000 where 1000 is normal, 0 is fast as possible)</summary>
  Public Property Speed() As Integer
    Get
      Return pSpeed
    End Get
    Set(ByVal Value As Integer)
      If Value >= 0 And Value <= 2000 And Value <> pSpeed Then
        pSpeed = Value
        DoSpeed()
      End If
    End Set
  End Property

  ''' <summary>Mute specified channel(s)</summary>
  Public Property Mute() As Channels
    Get
      Return pMute
    End Get
    Set(ByVal Value As Channels)
      If Value >= Channels.None And Value <= Channels.Both _
      And Value <> pMute Then
        pMute = Value
        DoMute()
      End If
    End Set
  End Property

  ''' <summary>Left/right Audio Balance (0-1000 where 500 is equal)</summary>
  Public Property Balance() As Integer
    Get
      Return pBalance
    End Get
    Set(ByVal Value As Integer)
      If Value >= 0 And Value <= 1000 And Value <> pBalance Then
        pBalance = Value
        DoBalance()
      End If
    End Set
  End Property

  ''' <summary>Audio Volume Level (0-1000 where 500 is normal)</summary>
  Public Property Volume() As Integer
    Get
      Return pVolume
    End Get
    Set(ByVal Value As Integer)
      If Value >= 0 And Value <= 1000 And Value <> pVolume Then
        pVolume = Value
        DoVolume()
      End If
    End Set
  End Property

  ' Control

  ''' <summary>Size media window to reflect new size</summary>
  Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
    SizeMediaWindow()
  End Sub

  ''' <summary>Close and Dispose</summary>
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    Me.Close()
    MyBase.Dispose(disposing)
  End Sub

  ''' <summary>Handle Autorepeat Messages</summary>
  ''' <param name="m">Windows Forms Message</param>
  Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    Select Case m.Msg
      Case MM_MCINOTIFY
        ' Only process message if success indicated
        If m.WParam.ToInt32 = MCI_NOTIFY_SUCCESSFUL Then
          If pRepeat = True Then
            Me.Stop()
            Me.Play()
          Else ' Raise End event to notify Media End
            Me.Stop()
            Dim e As New System.EventArgs
            RaiseEvent OnEnd(Me, e)
            e = Nothing
          End If
        End If
    End Select
    MyBase.WndProc(m)
  End Sub

  ' Event

  ''' <summary>Fired when Media ends</summary>  
  Public Event OnEnd(ByVal sender As Object, _
                     ByVal e As System.EventArgs)

End Class

