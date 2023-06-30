using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Compute.v1;
using Google.Apis.Compute.v1.Data;
using System.Net.Sockets;

namespace GCE_API_Test
{
    internal class Program
    {
        static GoogleCredential cred = GoogleCredential.FromFile(@"C:\BizData\source\GCE_API_Test\GCE_API_Test\GitIgnore\cred.json");
        static string _projectId = "rpm-2023";
        static string _zone = "asia-northeast3-a";
        static string _instanceName = "instance-1";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //var credential = cred.CreateScoped("https://www.googleapis.com/auth/compute-engine");

            ComputeService computeService = new ComputeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = cred,
                //ProjectId = _projectId
                ApplicationName = "Compute Engine API"
            });

            // 인스턴스 정보 가져오기
            InstancesResource.GetRequest getRequest = computeService.Instances.Get(_projectId, _zone, _instanceName);
            Instance response = getRequest.Execute();

            // 인스턴스의 SKU 정보 추출
            string skuId = "";
            //skuId = response.Scheduling.NodeAffinities[0].Values[0];
            
            // 결과 출력
            Console.WriteLine("id: " + response.Id.ToString());
            Console.WriteLine("skuId: " + skuId);
        }
    }
}