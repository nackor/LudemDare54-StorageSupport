using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FileGenerator : MonoBehaviour
{
    [SerializeField]
    public float FileSendRate = float.MaxValue;
    [SerializeField]
    Transform FileContentArea;
    [SerializeField]
    Item ItemPrefab;
    [SerializeField]
    int FolderChance = 80;
    [SerializeField]
    int BigFileRate = 70;
    [SerializeField]
    public Drive FTPDrive;
    float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > FileSendRate)
        {
            timer = 0;
            GenerateNewItem();
        }

        
    }

    private void GenerateNewItem()
    {
        Item newItem = Instantiate(ItemPrefab,FileContentArea);
        System.Random random = new System.Random();
        int realSize = 0;
        if (random.Next(101) > FolderChance)
        {
            realSize = random.Next((int)Math.Pow(10, 3),(int)Math.Pow(10, 7));
            int sizeRandom = random.Next(1,FileSizeMeasurements.Count);
            newItem.SizeMeasurement = FileSizeMeasurements[sizeRandom];
            string folderName = "";
            folderName += FolderNames[random.Next(FolderNames.Count)];
            
            newItem.Name = folderName;
            newItem.Extension = "folder";
            newItem.folderImage.gameObject.SetActive(true);
            
        }
        else
        {
            if (random.Next(101) > BigFileRate)
            {
                realSize = random.Next((int)Math.Pow(10, 4), (int)Math.Pow(10, 5) *9);
            }
            else
            {
                realSize = random.Next((int)Math.Pow(10, 2), (int)Math.Pow(10, 5));
            }
                
            if(realSize < 1000)
            {
                newItem.SizeMeasurement = FileSizeMeasurements[0];
            }
            else
            {
                newItem.SizeMeasurement = FileSizeMeasurements[1];
            }
          
            string fileName = "";

            fileName += FileNames[random.Next(FileNames.Count)];
            
            newItem.Name = fileName;
            newItem.Extension = Extensions[random.Next(Extensions.Count)];
            newItem.fileImage.gameObject.SetActive(true);
        }
        newItem.SetSize(realSize);
        try
        {
            FTPDrive.LongCurrent += newItem.LongSize;
        }catch(Exception ex)
        {
            return;
        }

        
    }

    void SetFileRate(float newRate)
    {
        FileSendRate = newRate;
    }


    private List<string> FileSizeMeasurements = new List<string>()
    {
        "KB",
        "MB",
        "GB"
    };
    private List<int> FileSizeMaxOptions = new List<int>()
    {
        0,
        3,
        6
    };

    private List<string> FolderNames = new List<string>()
    {
        "Plans",
        "CloudMigrationStrategy",
        "ITInfrastructurePlan",
        "CybersecurityTraining",
        "SoftwareDevelopmentPlan",
        "CryptKeeperFiles",
        "Documents",
        "Pictures",
        "Downloads",
        "ProgramFiles",
        "UserInterfaceMockups"
    };
    private List<string> FileNames = new List<string>()
    {
        "ProjectAlpha_Design",
        "CodeOptimizationGuide",
        "NetworkSecurityAudit",
        "DataAnalyticsReport",
        "HardwareInventory",
        "TechSupportManual", 
        "MobileAppWireframes",
        "DatabaseSchemaDiagram",
        "ServerConfiguration",
        "NetworkTopologyMap",
        "APIIntegrationGuide",
        "DevOpsAutomationScript",
        "ITPolicyHandbook",
        "ITBudgetProposal",
        "DisasterRecoveryPlan",
        "PQAReport",
        "COZGuide",
        "NSACheck",
        "DARInsights",
        "IIPStrategy",
        "CSTTraining",
        "CMSBlueprint",
        "SDPRoadmap",
        "HIList",
        "TSMHelp",
        "UIMSketches",
        "MAWDrafts",
        "DSDChart",
        "SCConfig",
        "NTMDiagram",
        "AIGReference",
        "DASScript",
        "ITHManual",
        "ITPBudget",
        "DRPFramework",
        "SinisterServerLogs",
        "MalwareManifesto",
        "GhostlyFirewallRules",
        "DarkWebAnalytics",
        "PhishingSchemeDatabase",
        "CyberCovenStrategies",
        "ZombieNetworkDiagram",
        "RansomwareResponsePlan",
        "ParanormalITAudit",
        "EvilBotDocumentation",
        "HauntedCodeRepository",
        "SinisterAlgorithmDesign",
        "VirusOutbreakReport",
        "OccultIncidentLog",
        "EldritchTechManual",
        "PoltergeistProtocol",
        "SpecterInfrastructure",
        "HexedITServices",
        "MalevolentAIResearch",
        "DarkCipherProject",
        "NightmareCode",
        "ShadowIntrusionNetwork",
        "DarkRitualsData",
        "DoomsdayITPlan",
        "EclipseCybersecurity",
        "ShroudedSecretsCloud",
        "DeathScriptSoftware",
        "CursedHardwareInventory",
        "HorrorTechSupportGuide",
        "BloodMockeryUI",
        "AbyssalWireframesMobileApp",
        "CrypticSchemaDatabase",
        "DemonicServerConfiguration",
        "ApocalypseTopologyNetwork",
        "HellishAPIIntegration",
        "NecromancyAutomationDevOps",
        "PactWithTheDarkIT",
        "BlackMagicBudgetProposal",
        "ChaosPlanDisasterRecovery",
        "LightspeedAPIIntegration",
        "RepublicBudgetProposal",
        "GalacticMapNetwork",
        "DataCoreSchematic",
        "CloudwalkerSecrets",
        "RebelIntrusionNetwork",
        "dog_picture",
        "dog",
        "NewDocument",
        "NewFile"
    };


    public List<string> Extensions = new List<string>
    {
        "jpg",
        "png",
        "tiff",
        "txt",
        "dll",
        "mp4",
        "mp3",
        "wav",
        "pdf",
        "exe"
    };
}
