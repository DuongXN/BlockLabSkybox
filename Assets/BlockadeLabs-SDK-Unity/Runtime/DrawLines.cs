using System.Collections.Generic;
using UnityEngine;

namespace BlockadeLabs_SDK_Unity.Runtime
{
    public class DrawLines : MonoBehaviour
    {
        public List<Vector3> linePoints = new();
        private LineRenderer lineRenderer;

        void Start()
        {
            // Tạo một LineRenderer để vẽ đoạn đường
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            // lineRenderer.startWidth = 0.1f;
            // lineRenderer.endWidth = 0.1f;
            //lineRenderer.positionCount = 0;
            // Tạo một vật liệu đơn giản để gán cho LineRenderer
            Material lineMaterial = new Material(Shader.Find("Standard"));

            // Đảm bảo rằng vật liệu sẽ hiển thị đủ phản xạ ánh sáng
            lineMaterial.SetFloat("_Glossiness", 0f);

            // Gán vật liệu cho LineRenderer
            //lineRenderer.material = lineMaterial;
        }

        void Update()
        {
            // Kiểm tra khi người dùng bấm chuột trái
            if (Input.GetMouseButtonDown(0))
            {
                // Lấy vị trí của chuột trong không gian 3D
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10.0f; // Khoảng cách từ camera đến mặt phẳng vẽ

                // Chuyển vị trí chuột từ màn hình (viewport) sang không gian thế giới
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

                // Thêm vị trí chuột vào danh sách các điểm cần vẽ
                linePoints.Add(worldPosition);

                // Cập nhật LineRenderer với danh sách các điểm
                lineRenderer.positionCount = linePoints.Count;
                lineRenderer.SetPositions(linePoints.ToArray());
            }
        }
    }
}