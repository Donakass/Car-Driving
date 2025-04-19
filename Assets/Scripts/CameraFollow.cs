using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // Ññûëêà íà îáúåêò ìàøèíû
    [SerializeField] private float distance = 10f; // Ðàññòîÿíèå êàìåðû îò ìàøèíû
    [SerializeField] private float height = 5f; // Âûñîòà êàìåðû íàä ìàøèíîé
    [SerializeField] private float smoothSpeed = 0.125f; // Ñêîðîñòü ñãëàæèâàíèÿ äâèæåíèÿ êàìåðû

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target äëÿ êàìåðû íå íàçíà÷åí!");
            return;
        }

        // Âû÷èñëÿåì ïîçèöèþ êàìåðû ïîçàäè ìàøèíû
        Vector3 targetPosition = target.position - target.forward * distance + Vector3.up * height;

        // Ïëàâíîå ïåðåìåùåíèå êàìåðû ê æåëàåìîé ïîçèöèè
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Êàìåðà âñåãäà ñìîòðèò íà ìàøèíó
        transform.LookAt(target);
    }
}

