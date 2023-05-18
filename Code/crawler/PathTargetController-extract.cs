private int i = 0;
public List<Vector3> positions;

public void MoveTargetToRandomPosition() {
    if (i < positions.Count) {
        transform.position = positions[i++];
    } else {
        var newTargetPos = m_startingPos + (Random.insideUnitSphere * spawnRadius);
        newTargetPos.y = m_startingPos.y;
        transform.position = newTargetPos;
    }
}