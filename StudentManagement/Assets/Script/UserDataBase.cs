using System.Collections;
using System.Collections.Generic;
using FullSerializer;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Text;

public class UserDataBase : MonoBehaviour
{
    [SerializeField] private RectTransform addAdminLoadingPanal;

    [SerializeField] private RectTransform addStudentLoadingPanal;

    [SerializeField] private RectTransform addResultLoadingPanal;

    [SerializeField] private RectTransform addReporLoadingtPanal;

    [SerializeField] private RectTransform addEventsLoadingPanal;

    [SerializeField] private RectTransform addNoticeLoadingPanal;

    [SerializeField] private Text scoreText;
    [SerializeField] private InputField getScoreText;

    [SerializeField] private InputField Data;

    [SerializeField] private InputField emailLogIn;
    [SerializeField] private InputField passwordLogIn;

    [SerializeField] private InputField emailTextSignUp;
    [SerializeField] private InputField usernameText;
    [SerializeField] private InputField passwordTextSignUp;
    [SerializeField] private InputField rollNoInputField;

    [SerializeField] private InputField lab;
    [SerializeField] private InputField system;
    [SerializeField] private InputField part;

    [SerializeField] private InputField adminEmailInputField;
    [SerializeField] private InputField adminNameInputField;
    [SerializeField] private InputField adminPasswordInputField;


    public static string reportData;

    [SerializeField] private Text userName;
    [SerializeField] private Text rollNoText;
    [SerializeField] private Text userEmailToshow;

    [SerializeField] private Text eventNameText;
    [SerializeField] private Text eventDiscreptionText;
    [SerializeField] private Text eventDurationText;

    [SerializeField] private RectTransform loginPanal, SignUpPanal, emailVerificationPanal, MenuPanal;

    [SerializeField] private Text errorText;
    [SerializeField] private Text reportErrorText;
    [SerializeField] private Text signUpErrorText;
    [SerializeField] private Text adminSubmitMarksError;
    [SerializeField] private Text addNoticeErrorText;
    [SerializeField] private Text addEventErrorText;

    //private bool userlogedIn = false;

    // private System.Random random = new System.Random(); 

    User user = new User();
    Report report = new Report();
    CountProblems noOfProblems = new CountProblems();

    private string databaseURL = "Replace this with firebase realtime database URL";
    private string AuthKey = "Replace this with firebase auth key";

    public static fsSerializer serializer = new fsSerializer();

    public static string eventNameInput;
    public static string eventDiscriptionInput;
    public static string eventUrlInput;
    public static string eventDurationInput;

    public static string studentRollNoInput;
    public static StringBuilder marksInput = new StringBuilder();

    [SerializeField] private InputField studentRollNoInputField;
    [SerializeField] private InputField examNameInputField;
    [SerializeField] private InputField subjectName;
    [SerializeField] private InputField subjectMarks;

    [SerializeField] private InputField noticeSubjectInputField;
    [SerializeField] private InputField noticeDiscriptionInputField;
    [SerializeField] private InputField noticeUrlInputField;
    public Dropdown noticeBranch;

    [SerializeField] private InputField eventTopicInputField;
    [SerializeField] private InputField eventDiscriptionInputField;
    [SerializeField] private InputField eventUrlInputField;
    [SerializeField] private InputField eventDurationInputField;

    public static string studentEmailId;
    public static string studentName;
    public static string studentRollNo;
    public static string studentBranch;

    public static string adminEmailInput;
    public static string adminNameInput;

    private string idToken;

    public static string localId;

    private string getLocalId;

    [SerializeField] private Text noticeSubjectOutput;
    [SerializeField] private Text noticeDiscriptionOutput;
    private string noticeKnowMoreUrl;

    public GameObject[] reportaprobleminputfield;
    public GameObject submitedlogo;
    public GameObject loadingLogo;

    int i = 0;

    public static int numberOfProb;

    public Image backGroundTheamImage;
    public Image theamImage;

    public Image[] scrollView;

    public Color[] scrollViewColor;

    [SerializeField] private Text ResultText;
    [SerializeField] private Text ExamNameText;
    //public Button theamButton;

    //public string[] AdminEmail;

    public GameObject[] AdminPanal, StudentPanal;

    int x = 0;

    bool IsAdmin = false;

    [SerializeField] private InputField addStudentRollNo;
    [SerializeField] private InputField addStudentEmail;

    public Dropdown dipartmentDropDown;
    private string DipartMant;

    public Dropdown teacherName;

    [SerializeField] private Text addStudenterrotText;
    [SerializeField] private Text addAdminerrorText;

    public GameObject problemListItemPrefab;
    public Transform problemListParent;

    [SerializeField] private Text adminProblemStatus;

    public Button noticeKnowMoreButton;

    List<GameObject> problemList = new List<GameObject>();

    public void OnMarksAdd()
    {
        adminSubmitMarksError.gameObject.SetActive(false);
        if (studentRollNoInputField.text != "" && examNameInputField.text != "" && subjectName.text != "" && subjectMarks.text != "")
        {
            marksInput.Append($"{subjectName.text}:{subjectMarks.text}/");
        }
        else
        {
            adminSubmitMarksError.gameObject.SetActive(true);
            adminSubmitMarksError.text = "Fill all the fields";
            Debug.Log("Fill all the fields");
        }

        subjectName.text = null;
        subjectMarks.text = null;
    }

    public void OnMarksSubmit()
    {
        addResultLoadingPanal.gameObject.SetActive(true);
        marksInput.Append($"{examNameInputField.text}/{marksInput}");
        PutMarksOfUser();
        studentRollNoInputField.text = null;
    }

    private void TranslateMarks(string Marks)
    {
        addResultLoadingPanal.gameObject.SetActive(true);
        Debug.Log(Marks);
        ResultText.text = "";
        string[] dataPieces = Marks.Split('/');
        ExamNameText.text = dataPieces[0];

        StringBuilder sb = new StringBuilder();

        for (i = 1; i < dataPieces.Length; i++)
        {
            sb.Append($"{dataPieces[i]}\n");
        }
        ResultText.text += sb;
        addResultLoadingPanal.gameObject.SetActive(false);
    }

    public void appColour()
    {
        if (x == 0)
        {
            backGroundTheamImage.color = Color.black;
            for (i = 0; i < scrollView.Length; i++)
            {
                scrollView[i].color = scrollViewColor[0];
            }
            theamImage.gameObject.SetActive(true);
            x = 1;
        }
        else
        {
            backGroundTheamImage.color = Color.white;
            for (i = 0; i < scrollView.Length; i++)
            {
                scrollView[i].color = scrollViewColor[1];
            }
            theamImage.gameObject.SetActive(false);
            x = 0;
        }
    }

    public void OnGetScore()
    {
        GetLocalId();
    }

    private void UpdateScore()
    {
        scoreText.text = $"Score: {user.userEmail}";
    }

    private void UpdateProblem(string resivedProblem)
    {
        Debug.Log(resivedProblem);
        string[] dataPieces = resivedProblem.Split('/');
        GameObject _problemItem = Instantiate(problemListItemPrefab);
        _problemItem.transform.SetParent(problemListParent);
        _problemItem.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0);
        // Debug.Log($"LabNo.:{dataPieces[0]} SystemNo. : {dataPieces[2]} Part: {dataPieces[3]}");
    }


    private void PostToDatabase(string idTokenTemp = "")
    {
        if (idTokenTemp == "")
        {
            idTokenTemp = idToken;
        }

        RestClient.Put($"{databaseURL}/Users/{localId}.json?auth={idTokenTemp}", new User());

        SignUpButtonInSignUpWindow();
    }

    private void AddAdminToDataBase(string adminId)
    {
        AdminData adminData = new AdminData();
        Debug.Log(adminId);
        RestClient.Put($"{databaseURL}/Admin/{adminId}.json?auth={idToken}", adminData);
        addAdminLoadingPanal.gameObject.SetActive(false);
        StartCoroutine(ShowSubmited());
    }

    private void RetrieveFromDatabase()
    {
        RestClient.Get<User>($"{databaseURL}/Users/{getLocalId}.json?auth={idToken}").Then(response =>
            {
                user = response;
                UpdateScore();
            });
    }


    public void Report()
    {
        if (lab.text != "" && system.text != "" && part.text != "")
        {
            addReporLoadingtPanal.gameObject.SetActive(true);
            reportErrorText.gameObject.SetActive(false);
            reportData = $"Lab: {lab.text}/SNo.: {system.text}/{part.text}";
            TotalNumberOfProblems();
        }
        else
        {
            reportErrorText.gameObject.SetActive(true);
            reportErrorText.text = "All fields Must be filed.";
            Debug.Log("All fields must be filed");
        }
    }

    private void PostProblem(string idTokenTemp = "")
    {
        if (idTokenTemp == "")
        {
            idTokenTemp = idToken;
        }

        Report report = new Report();

        RestClient.Put($"{databaseURL}/Problems/{numberOfProb}.json?auth={idTokenTemp}", report);

        numberOfProb++;

        CountProblems problemNo = new CountProblems();

        RestClient.Put($"{databaseURL}/TotalNumberOfProblems/.json?auth={idTokenTemp}", problemNo);

        addReporLoadingtPanal.gameObject.SetActive(false);
        StartCoroutine(ShowSubmited());


        lab.text = null;
        system.text = null;
        part.text = null;
    }

    IEnumerator ShowSubmited()
    {
        submitedlogo.SetActive(true);

        yield return new WaitForSeconds(1);

        submitedlogo.SetActive(false);
    }

    public void DeletData()
    {
        RestClient.Delete($"{databaseURL}/Problems/.json?aoth={idToken}");

        numberOfProb = 0;

        CountProblems problemNo = new CountProblems();

        RestClient.Put($"{databaseURL}/TotalNumberOfProblems/.json?auth={idToken}", problemNo);
        for (int i = 0; i < problemList.Count; i++)
        {
            Destroy(problemList[i]);
        }

        problemList.Clear();
    }

    public void RefreshReportedProblem()
    {
        adminProblemStatus.text = "Loading...";
        for (int i = 0; i < problemList.Count; i++)
        {
            Destroy(problemList[i]);
        }

        problemList.Clear();
        addReporLoadingtPanal.gameObject.SetActive(true);
        TotalNumberOfProblems();
    }

    private void getProblem()
    {
        for (int y = 0; y < numberOfProb; y++)
        {
            RestClient.Get<Report>($"{databaseURL}/Problems/{y}.json?auth={idToken}").Then(response =>
            {
                GameObject _problemItem = Instantiate(problemListItemPrefab);
                _problemItem.transform.SetParent(problemListParent);
                _problemItem.transform.GetChild(0).GetComponent<Text>().text = response.dat;
                _problemItem.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0);

                problemList.Add(_problemItem);


                adminProblemStatus.text = "";
            }).Catch(error =>
            {
                addReporLoadingtPanal.gameObject.SetActive(false);
                adminProblemStatus.text = "No reported problem found!";
            });
        }
        if (problemList.Count == 0)
        {
            addReporLoadingtPanal.gameObject.SetActive(false);
            adminProblemStatus.text = "No reported problem found!";
        }
    }

    private void TotalNumberOfProblems()
    {
        RestClient.Get<CountProblems>($"{databaseURL}/TotalNumberOfProblems.json?auth={idToken}").Then(response =>
        {
            noOfProblems = response;
            numberOfProb = noOfProblems.totalNoOfProblems;
            if (!IsAdmin)
            {
                PostProblem();
            }
            else
            {
                getProblem();
            }
        }).Catch(error =>
        {
            //addReporLoadingtPanal.gameObject.SetActive(false);
        });
    }

    //public void SignUp()
    //{
    //  errorText.gameObject.SetActive(false);
    //StartCoroutine(SignUpButtonInLogInwindow());
    //}

    //public void SignUpIn()
    //{
    //  StartCoroutine(SignUpButtonInSignUpWindow());
    //}

    public void SignOut()
    {
        for (int i = 0; i < problemList.Count; i++)
        {
            Destroy(problemList[i]);
        }

        problemList.Clear();


        adminNameInputField.text = null;
        adminPasswordInputField.text = null;
        adminEmailInputField.text = null;

        DipartMant = null;
        localId = null;
        addAdminLoadingPanal.gameObject.SetActive(false);
        addStudentLoadingPanal.gameObject.SetActive(false);
        addResultLoadingPanal.gameObject.SetActive(false);
        addNoticeLoadingPanal.gameObject.SetActive(false);
        addEventsLoadingPanal.gameObject.SetActive(false);
        addReporLoadingtPanal.gameObject.SetActive(false);

        noticeSubjectOutput.text = null;
        noticeKnowMoreUrl = null;

        addEventErrorText.text = null;
        addNoticeErrorText.text = null;
        adminSubmitMarksError.text = null;
        reportErrorText.text = null;
        addStudenterrotText.text = null;
        addAdminerrorText.text = null;


        MenuPanal.gameObject.SetActive(false);
        loginPanal.gameObject.SetActive(true);
        if (IsAdmin)
        {
            for (i = 0; i < AdminPanal.Length; i++)
            {
                AdminPanal[i].gameObject.SetActive(false);
            }
        }
        else
        {
            for (i = 0; i < StudentPanal.Length; i++)
            {
                StudentPanal[i].gameObject.SetActive(false);
            }
        }
        IsAdmin = false;
    }

    public void SignUp()
    {
        emailTextSignUp.text = null;
        passwordTextSignUp.text = null;
        userName.text = null;
        rollNoInputField.text = null;
        errorText.gameObject.SetActive(false);
        SignUpPanal.gameObject.SetActive(true);
        emailLogIn.text = null;
        passwordLogIn.text = null;
        loginPanal.gameObject.SetActive(false);
    }

    void SignUpButtonInSignUpWindow()
    {
        emailVerificationPanal.gameObject.SetActive(true);
        SignUpPanal.gameObject.SetActive(false);
    }

    public void LoginOnEmailVerification()
    {
        loginPanal.gameObject.SetActive(true);
        emailVerificationPanal.gameObject.SetActive(false);
    }

    public void IfAdmin()
    {
        errorText.gameObject.SetActive(false);
        if (emailLogIn.text != "" && passwordLogIn.text != "")
        {
            RestClient.Get($"{databaseURL}Admin.json").Then(response =>
            {
                var adminEmailCheck = emailLogIn.text;

                fsData userData = fsJsonParser.Parse(response.Text);
                Dictionary<string, AdminData> users = null;
                serializer.TryDeserialize(userData, ref users);

                foreach (var user in users.Values)
                {
                    if (user.adminEmail == adminEmailCheck)
                    {
                        IsAdmin = true;
                        SignInUser(emailLogIn.text, passwordLogIn.text);
                        Debug.Log("Admin");
                        break;
                    }
                    else
                    {
                        IsAdmin = false;
                        SignInUser(emailLogIn.text, passwordLogIn.text);
                        Debug.Log("Not An Admin");
                        break;
                    }
                }
            }).Catch(error =>
            {
                Debug.Log(error);
            });
        }
        else
        {
            errorText.gameObject.SetActive(true);
            errorText.text = "Fill out all the fields";
        }
    }

    private void LogIn()
    {
        if (IsAdmin)
        {
            GetAdminDetail();
        }
        else
        {
            GetUserDetail();
        }
    }

    private void SetUpAdminPanal()
    {
        for (i = 2; i < AdminPanal.Length; i++)
        {
            AdminPanal[i].gameObject.SetActive(true);
        }
        loginPanal.gameObject.SetActive(false);
        MenuPanal.gameObject.SetActive(true);
        emailLogIn.text = null;
        passwordLogIn.text = null;
    }

    public void SetUpStudentPanal()
    {
        for (i = 0; i < StudentPanal.Length; i++)
        {
            StudentPanal[i].gameObject.SetActive(true);
        }
        loginPanal.gameObject.SetActive(false);
        MenuPanal.gameObject.SetActive(true);
        emailLogIn.text = null;
        passwordLogIn.text = null;
    }

    public void BackButton()
    {
        signUpErrorText.gameObject.SetActive(false);
        loginPanal.gameObject.SetActive(true);
        SignUpPanal.gameObject.SetActive(false);
        emailTextSignUp.text = null;
        passwordTextSignUp.text = null;
        userName.text = null;
        rollNoInputField.text = null;
    }

    public void SignUpUserButton()
    {
        if (emailTextSignUp.text != "" && usernameText.text != "" && rollNoInputField.text != "" && passwordTextSignUp.text != "")
        {
            signUpErrorText.gameObject.SetActive(false);
            StudentDipartmentSignUp();
        }
        else
        {
            signUpErrorText.gameObject.SetActive(true);
            signUpErrorText.text = "All fields must be filled.";
        }
    }

    public void SignInUserButton()
    {
        errorText.gameObject.SetActive(false);
        SignInUser(emailLogIn.text, passwordLogIn.text);
    }

    private void SignUpUser(string email, string username, string rollNoOfstudent, string password)
    {
        string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";
        RestClient.Post<SignResponse>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key=" + AuthKey, userData).Then(
            response =>
            {
                string emailVerification = "{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"" + response.idToken + "\"}";
                RestClient.Post(
                    "https://www.googleapis.com/identitytoolkit/v3/relyingparty/getOobConfirmationCode?key=" + AuthKey,
                    emailVerification);
                if (IsAdmin)
                {
                    Debug.Log("Admin to data");
                    AddAdminToDataBase(response.localId);
                }
                else
                {
                    localId = response.localId;
                    studentName = username;
                    studentRollNo = rollNoOfstudent.ToUpper();
                    studentEmailId = email;
                    PostToDatabase(response.idToken);
                }
            }).Catch(error =>
        {
            if (IsAdmin)
            {
                addAdminerrorText.gameObject.SetActive(true);
                addAdminLoadingPanal.gameObject.SetActive(false);
                if (error.Message == "Cannot resolve destination host")
                {
                    addAdminerrorText.text = "Connection problem!";
                }
                else
                {
                    addAdminerrorText.text = "Admin already exist or password is not strong.";
                }
            }
            else
            {

                Debug.Log(error);
                signUpErrorText.gameObject.SetActive(true);
                if (error.Message == "Cannot resolve destination host")
                {
                    signUpErrorText.text = "Connection problem!";
                }
                else
                {
                    signUpErrorText.text = "Enter a password with at least 4 character and 4 numbers.";
                }
            }
        });
    }

    private void SignInUser(string email, string password)
    {
        string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";
        RestClient.Post<SignResponse>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=" + AuthKey, userData).Then(
            response =>
            {
                string emailVerification = "{\"idToken\":\"" + response.idToken + "\"}";
                RestClient.Post(
                    "https://www.googleapis.com/identitytoolkit/v3/relyingparty/getAccountInfo?key=" + AuthKey,
                    emailVerification).Then(
                    emailResponse =>
                    {
                        fsData emailVerificationData = fsJsonParser.Parse(emailResponse.Text);
                        EmailConfirmationInfo emailConfirmationInfo = new EmailConfirmationInfo();
                        serializer.TryDeserialize(emailVerificationData, ref emailConfirmationInfo).AssertSuccessWithoutWarnings();

                        if (emailConfirmationInfo.users[0].emailVerified)
                        {
                            idToken = response.idToken;
                            localId = response.localId;
                            LogIn();
                        }
                        else
                        {
                            errorText.gameObject.SetActive(true);
                            Debug.Log("You are stupid, you need to verify your email dumb");
                            errorText.text = "You need to verify your email first.";
                        }
                    });

            }).Catch(error =>
        {
            Debug.Log(error);
            errorText.gameObject.SetActive(true);
            if (error.Message == "Cannot resolve destination host")
            {
                signUpErrorText.text = "Connection problem!";
            }
            else
            {
                errorText.text = "Email and Password doesn't match.";
            }
        });
    }

    private void GetUserDetail()
    {
        RestClient.Get<User>($"{databaseURL}/Users/{localId}.json?auth={idToken}").Then(response =>
        {
            userName.text = response.userName;
            rollNoText.text = response.rollNo;
            DipartMant = response.userDipartment;
            GetNoticeData();
            GetMarks();
            userEmailToshow.text = response.userEmail;
            SetUpStudentPanal();
            StartCoroutine(UpdateAllItem());
        });
    }

    private void GetAdminDetail()
    {
        RestClient.Get<AdminData>($"{databaseURL}/Admin/{localId}.json?auth={idToken}").Then(response =>
        {
            userName.text = response.adminName;
            rollNoText.text = "Admin";
            userEmailToshow.text = response.adminEmail;
            TotalNumberOfProblems();
            SetUpAdminPanal();
            StartCoroutine(UpdateAllItem());
        });
    }

    private void GetEvent()
    {
        RestClient.Get<EventDetails>($"{databaseURL}/Events.json?auth={idToken}").Then(response =>
        {
            eventNameText.text = response.eventName;
            eventDiscreptionText.text = response.eventDecription;
            Menu.eventurl = response.eventUrl;
            eventDurationText.text = response.eventDuration;
        });
    }

    private void GetMarks()
    {
        RestClient.Get<StudentMarks>($"{databaseURL}/Marks/{rollNoText.text}.json?auth={idToken}").Then(response =>
        {
            TranslateMarks(response.marksString);
            Debug.Log(response.marksString);
        }).Catch(error =>
        {
            ResultText.text = "Result not found.";
        });

        addResultLoadingPanal.gameObject.SetActive(false);
    }

    private void GetLocalId()
    {
        RestClient.Get($"{databaseURL}Users.json?auth={idToken}").Then(response =>
        {
            var username = getScoreText.text;

            fsData userData = fsJsonParser.Parse(response.Text);
            Dictionary<string, User> users = null;
            serializer.TryDeserialize(userData, ref users);

            foreach (var user in users.Values)
            {
                if (user.userName == username)
                {
                    getLocalId = user.localId;
                    RetrieveFromDatabase();
                    break;
                }
            }
        }).Catch(error =>
        {
            Debug.Log(error);
        });
    }
    /*
    private void getdataof()
    {
        RestClient.Get(databaseURL + "/" + "Users" + "/" + ".json?auth=" + idToken).Then(response =>
        {
            var userRollNo = studentRollNoInputField.text;
            Debug.Log("1");
            fsData userData = fsJsonParser.Parse(response.Text);
            Dictionary<string, User> users = null;
            serializer.TryDeserialize(userData, ref users);

            foreach (var user in users.Values)
            {
                if (user.rollNo == userRollNo)
                {
                    getLocalId = user.localId;
                    PutMarksOfUser();
                    break;
                }
                else
                {
                    marksInput = "";
                    Debug.Log("No User with this rollNo.");
                }
            }
        }).Catch(error =>
        {
            Debug.Log(error);
        });
    }
    */
    private void PutMarksOfUser()
    {
        StudentMarks StuMarks = new StudentMarks();

        RestClient.Put($"{databaseURL}/Marks/{studentRollNoInputField.text.ToUpper()}.json?auth={idToken}", StuMarks).Then(response =>
        {
            StartCoroutine(ShowSubmited());
        });
        marksInput = null;
        addResultLoadingPanal.gameObject.SetActive(false);
    }

    public void AddStudentButton()
    {
        addStudenterrotText.gameObject.SetActive(false);
        if (addStudentEmail.text != "" && addStudentRollNo.text != "")
        {
            addStudentLoadingPanal.gameObject.SetActive(true);
            if (dipartmentDropDown.value == 0)
            {
                DipartMant = "CSE";
                AddStudent();
            }
            else if (dipartmentDropDown.value == 1)
            {
                DipartMant = "ME";
                AddStudent();
            }
            else if (dipartmentDropDown.value == 2)
            {
                DipartMant = "ECE";
                AddStudent();
            }
            else if (dipartmentDropDown.value == 3)
            {
                DipartMant = "CE";
                AddStudent();
            }
            else if (dipartmentDropDown.value == 4)
            {
                DipartMant = "EE";
                AddStudent();
            }
            else
            {
                addStudenterrotText.gameObject.SetActive(true);
                Debug.Log("Wrong RollNo. formet");
                addStudenterrotText.text = "Wrong RollNo. formet";
            }
        }
        else
        {
            addStudenterrotText.gameObject.SetActive(true);
            addStudenterrotText.text = "Fill all the fields";
        }
        addStudentEmail.text = null;
        addStudentRollNo.text = null;
    }

    private void AddStudent()
    {
        studentEmailId = addStudentEmail.text;
        studentRollNo = addStudentRollNo.text.ToUpper();

        Students studentsdata = new Students();

        RestClient.Put($"{databaseURL}/Students/{DipartMant}/{studentRollNo}.json?auth={idToken}", studentsdata).Catch(response =>
        {
            addStudenterrotText.gameObject.SetActive(true);
            addStudenterrotText.text = "Network Problem!";
        }).Catch(error =>
        {
            Debug.Log("hg");
            Debug.Log(error);
        });
        addStudentLoadingPanal.gameObject.SetActive(false);
    }

    private void StudentDipartmentSignUp()
    {
        DipartMant = rollNoInputField.text[2] + rollNoInputField.text[3].ToString();
        if (DipartMant.ToUpper() == "CS")
        {
            DipartMant = "CSE";
        }
        else if (DipartMant.ToUpper() == "EC")
        {
            DipartMant = "ECE";
        }
        IfStudent();
    }

    private void IfStudent()
    {
        RestClient.Get<Students>($"{databaseURL}/Students/{DipartMant.ToUpper()}/{rollNoInputField.text.ToUpper()}.json").Then(response =>
        {
            if (response.studentEmail == emailTextSignUp.text && response.studentRollNo == rollNoInputField.text.ToUpper())
            {
                studentBranch = DipartMant.ToUpper();
                SignUpUser(emailTextSignUp.text, usernameText.text, rollNoInputField.text, passwordTextSignUp.text);
            }
            else
            {
                signUpErrorText.gameObject.SetActive(true);
                signUpErrorText.text = "You are not allowed to register.";
            }
        }).Catch(error =>
        {
            Debug.Log(error);
            signUpErrorText.gameObject.SetActive(true);
            signUpErrorText.text = "Error occured, Ask an Admin to solve it.";
        });
    }

    public void AddAdmin()
    {
        addAdminerrorText.gameObject.SetActive(false);
        if (adminEmailInputField.text != "" && adminNameInputField.text != "" && adminPasswordInputField.text != "")
        {
            addAdminLoadingPanal.gameObject.SetActive(true);
            adminEmailInput = adminEmailInputField.text;
            adminNameInput = adminNameInputField.text;
            SignUpUser(adminEmailInputField.text, adminNameInputField.text, "", adminPasswordInputField.text);
        }
        else
        {
            addAdminerrorText.gameObject.SetActive(true);
            addAdminerrorText.text = "Fill all the fields";
        }

        adminNameInputField.text = null;
        adminPasswordInputField.text = null;
        adminEmailInputField.text = null;
    }

    public void PutNotiveButton()
    {
        addNoticeErrorText.gameObject.SetActive(false);

        if (noticeDiscriptionInputField.text != "" && noticeSubjectInputField.text != "")
        {
            addNoticeLoadingPanal.gameObject.SetActive(true);
            eventNameInput = noticeSubjectInputField.text;
            eventDiscriptionInput = noticeDiscriptionInputField.text;
            eventUrlInput = noticeUrlInputField.text;
            if (noticeBranch.value == 0)
            {
                DipartMant = "All";
                PutNoticeInDataBase();
            }
            else if (noticeBranch.value == 1)
            {
                DipartMant = "CSE";
                PutNoticeInDataBase();
            }
            else if (noticeBranch.value == 2)
            {
                DipartMant = "ME";
                PutNoticeInDataBase();
            }
            else if (noticeBranch.value == 3)
            {
                DipartMant = "ECE";
                PutNoticeInDataBase();
            }
            else if (noticeBranch.value == 4)
            {
                DipartMant = "CE";
                PutNoticeInDataBase();
            }
            else if (noticeBranch.value == 5)
            {
                DipartMant = "EE";
                PutNoticeInDataBase();
            }
        }
        else
        {
            addNoticeErrorText.gameObject.SetActive(true);
            addNoticeErrorText.text = "All fiels must be filled.";
        }

        noticeDiscriptionInputField.text = null;
        noticeSubjectInputField.text = null;
        noticeUrlInputField.text = null;
    }

    private void PutNoticeInDataBase()
    {
        Notice noticeData = new Notice();
        RestClient.Put($"{databaseURL}/Notice/{DipartMant}.json?auth={idToken}", noticeData).Then(response =>
        {
            addNoticeLoadingPanal.gameObject.SetActive(false);
            StartCoroutine(ShowSubmited());
            Debug.Log("Done");
        }).Catch(error =>
        {
            addNoticeLoadingPanal.gameObject.SetActive(false);
        });
    }

    private void GetNoticeData()
    {
        RestClient.Get<Notice>($"{databaseURL}/Notice/{DipartMant}.json?auth={idToken}").Then(response =>
        {

            noticeSubjectOutput.text = response.noticeSubject;
            noticeDiscriptionOutput.text = response.noticeDiscription;
            noticeKnowMoreUrl = response.noticeUrl;

            if (noticeSubjectOutput.text == "")
            {
                GetNoticeAllData();
            }
            if (noticeKnowMoreUrl == "")
            {
                Debug.Log("Know more Button is false 2");
                noticeKnowMoreButton.gameObject.SetActive(false);
            }
        }).Catch(error =>
        {

            if (noticeSubjectOutput.text == "")
            {
                GetNoticeAllData();
            }
            Debug.Log(error);
        });
    }

    void GetNoticeAllData()
    {
        RestClient.Get<Notice>($"{ databaseURL}/Notice/All.json?auth={idToken}").Then(response =>
        {

            noticeSubjectOutput.text = response.noticeSubject;
            noticeDiscriptionOutput.text = response.noticeDiscription;
            noticeKnowMoreUrl = response.noticeUrl;
            Debug.Log(response);
            //yield return new WaitForSeconds(5);
            if (noticeKnowMoreUrl == "")
            {
                Debug.Log("Know more Button is false 2");
                noticeKnowMoreButton.gameObject.SetActive(false);
            }
            else
            {
                noticeKnowMoreButton.gameObject.SetActive(true);
                Debug.Log("Know more Button is true 2");
            }
        }).Catch(error =>
        {
            Debug.Log(error);
        });
    }

    public void NoticeKnowMore()
    {
        Debug.Log(noticeKnowMoreUrl);
        Application.OpenURL(noticeKnowMoreUrl);
    }

    public void AddEventButton()
    {
        addEventErrorText.text = "";
        if (eventDiscriptionInputField.text != "" && eventTopicInputField.text != "")
        {
            addEventsLoadingPanal.gameObject.SetActive(true);
            eventDiscriptionInput = eventDiscriptionInputField.text;
            eventNameInput = eventTopicInputField.text;
            eventUrlInput = eventUrlInputField.text;
            eventDurationInput = eventDurationInputField.text;
            PutEventToDatabase();
        }
        else
        {
            addEventErrorText.text = "Must fill event name and event discription.";
        }
    }

    private void PutEventToDatabase()
    {
        EventDetails eventData = new EventDetails();
        RestClient.Put($"{databaseURL}/Event.json?auth={idToken}", eventData).Then(response =>
        {
            addEventsLoadingPanal.gameObject.SetActive(false);
            StartCoroutine(ShowSubmited());
            Debug.Log("Event is Done");
        }).Catch(error =>
        {
            addEventsLoadingPanal.gameObject.SetActive(false);
        });
    }

    public void ReloadResult()
    {
        ResultText.text = "Loading...";
        addResultLoadingPanal.gameObject.SetActive(true);
        GetMarks();
    }

    IEnumerator UpdateAllItem()
    {
        yield return new WaitForSeconds(6);
        if (IsAdmin)
        {
            //getProblem();
        }
        if (!IsAdmin)
        {
            GetNoticeData();
            GetMarks();
        }
        StartCoroutine(UpdateAllItem());
    }

}
